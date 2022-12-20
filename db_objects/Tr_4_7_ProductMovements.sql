CREATE TRIGGER movementControl ON ProductMovements
INSTEAD OF INSERT, UPDATE
AS
	DECLARE @supplier SMALLINT, @count INT, @order INT, @product INT;
	
	SELECT @supplier = supplierCode, @count = productCount, @order = orderNumber, @product = productCode
	FROM inserted

	IF @supplier IS NOT NULL -- проверяем поставщика
	BEGIN
		IF @count < 0
		BEGIN
			RAISERROR('Поставщик не может быть указан при отрицательном количестве товара', 16, 1)
			RETURN
		END

		IF @order IS NOT NULL
		BEGIN
			RAISERROR('Поставщик не может быть указан при указанном номере заказа', 16, 1)
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

		SELECT @discount = discountPercentage FROM Customers WHERE id = @customer

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


  -- пересчёт стоимости заказа при удалении движения
CREATE TRIGGER movementDelControl ON ProductMovements
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

		SELECT @discount = discountPercentage FROM Customers WHERE id = @customer

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