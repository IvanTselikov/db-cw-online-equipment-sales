USE OnlineEquipmentSales;
GO

-- т.к. скидка прив€зана к заказу, а не к клиенту (у клиента она мен€етс€
-- с течением времени, у заказа - нет), то хранить скидку в таблице Customers
-- нецелесообразно
ALTER TABLE Customers
DROP COLUMN discountPercentage;

-- создадим поле discountPrc в таблице Orders
ALTER TABLE Orders
ADD discountPrc TINYINT NOT NULL DEFAULT 0;

ALTER TABLE Orders
ADD CONSTRAINT FK_Orders_discountPrc FOREIGN KEY (discountPrc) references Discounts([percentage]);
GO

-- текущую скидку клиента будем получать из ’ѕ
CREATE PROCEDURE sp_GetCustomerDiscount
  @customerId INT, @discount TINYINT OUTPUT
AS
	DECLARE @ordersSum MONEY, @discountTotal TINYINT = 0

	SELECT @ordersSum = SUM(sum)
	FROM Orders
	WHERE statusCode = 11 AND customerId = @customerId -- сумма полученных заказов

	DECLARE @crsrPrc TINYINT, @purchases MONEY
	DECLARE discount_cursor CURSOR LOCAL FOR
	SELECT percentage, purchasesAmount
	FROM Discounts
	ORDER BY percentage
	OPEN discount_cursor
	FETCH NEXT FROM discount_cursor INTO @crsrPrc, @purchases
	WHILE @@FETCH_STATUS=0
	BEGIN
	IF @ordersSum >= @purchases
		SET @discountTotal = @crsrPrc
	FETCH NEXT FROM discount_cursor INTO @crsrPrc, @purchases
	END
	CLOSE discount_cursor
	DEALLOCATE discount_cursor

	SET @discount = @discountTotal
GO

-- установить скидку на новый заказ
CREATE TRIGGER tr_SetNewOrderDiscount
ON Orders
AFTER INSERT
AS
	DECLARE @order INT, @discount TINYINT, @customer INT

	SELECT @order = number, @customer = customerId
	FROM inserted

	EXEC sp_GetCustomerDiscount @customer, @discount OUTPUT

	UPDATE Orders
	SET discountPrc = @discount
	WHERE number = @order
GO

--4 --7
ALTER TRIGGER tr_MovementControl
ON ProductMovements
INSTEAD OF INSERT, UPDATE
AS
	DECLARE @supplier SMALLINT, @count INT, @order INT, @product INT;
	
	SELECT @supplier = supplierCode, @count = productCount, @order = orderNumber, @product = productCode
	FROM inserted

	IF @supplier IS NOT NULL -- провер€ем поставщика
	BEGIN
		IF @count < 0
		BEGIN
			RAISERROR('ѕоставщик не может быть указан при отрицательном количестве товара', 16, 1)
			RETURN
		END

		IF @order IS NOT NULL
		BEGIN
			RAISERROR('ѕоставщик не может быть указан при указанном номере заказа', 16, 1)
			RETURN
		END
	END
	
	IF @supplier IS NULL AND @order IS NOT NULL -- пересчитываем сумму заказа
	BEGIN
		DECLARE @orderSum MONEY, @wsPrice MONEY, @wsCount INT, @price MONEY, @maxDiscount INT, @discount INT, @customer INT;

		SELECT @price = retailPrice, @wsPrice = wholesalePrice, @wsCount = wholesaleQuantity, @maxDiscount = maxDiscountPercentage
		FROM Products
		WHERE code = @product

		SELECT @customer = customerId, @orderSum = sum
		FROM Orders
		WHERE number = @order

		SELECT @discount = discountPrc FROM Orders WHERE number = @order			

		IF (@discount > @maxDiscount)
			SET @discount = @maxDiscount;
		

		DECLARE @addToSum MONEY;
		SELECT @addToSum = 
		CASE WHEN -productCount >= @wsCount THEN -productCount*@wsPrice*((100-@discount)/100.0)
											ELSE -productCount*@price*((100-@discount)/100.0) END
		FROM inserted
		WHERE productCount<0

		IF @addToSum IS NULL
			SET @addToSum = 0

		SELECT @orderSum = @addToSum + @orderSum;

		UPDATE Orders
		SET sum = @orderSum
		WHERE number = @order
	END

	INSERT INTO ProductMovements
	SELECT warehouseNumber, productCode, productCount, supplierCode, orderNumber, movementDate FROM inserted
GO

--7 пересчЄт стоимости заказа при удалении движени€
ALTER TRIGGER tr_MovementDelControl
ON ProductMovements
AFTER DELETE
AS
	DECLARE @supplier SMALLINT, @count INT, @order INT, @product INT;
	
	SELECT @supplier = supplierCode, @count = productCount, @order = orderNumber, @product = productCode
	FROM deleted
		
	IF @supplier IS NULL AND @order IS NOT NULL -- пересчитываем сумму заказа
	BEGIN
		DECLARE @orderSum MONEY, @wsPrice MONEY, @wsCount INT, @price MONEY, @maxDiscount INT, @discount INT, @customer INT;

		SELECT @price = retailPrice, @wsPrice = wholesalePrice, @wsCount = wholesaleQuantity, @maxDiscount = maxDiscountPercentage
		FROM Products
		WHERE code = @product

		SELECT @customer = customerId, @orderSum = sum
		FROM Orders
		WHERE number = @order

		SELECT @discount = discountPrc FROM Orders WHERE number = @order

		--EXEC sp_GetCustomerDiscount @customer, @discount OUTPUT

		IF (@discount > @maxDiscount)
			SET @discount = @maxDiscount;
				
		DECLARE @discardFromSum MONEY;
		SELECT @discardFromSum = 
		CASE WHEN -productCount >= @wsCount THEN -productCount*@wsPrice*((100-@discount)/100.0)
											ELSE -productCount*@price*((100-@discount)/100.0) END
		FROM deleted
		WHERE productCount<0

		IF @discardFromSum IS NULL
			SET @discardFromSum = 0

		SELECT @orderSum = @orderSum - @discardFromSum;
				
		UPDATE Orders
		SET sum = @orderSum
		WHERE number = @order
	END
