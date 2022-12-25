--USE OnlineEquipmentSales;
--GO

--CREATE TRIGGER tr_CanceledOrderProducts ON Orders
--INSTEAD OF UPDATE 
--AS
--	DECLARE @transactionDate DATE, @status TINYINT, @order INT, @orderSum MONEY;
--	SET @transactionDate = GETDATE()
	
--	SELECT @order = number, @status = statusCode, @orderSum = sum
--	FROM inserted
	
--	IF @status = 12 -- статус "отменён
--	BEGIN		

--		DECLARE @warehouse INT, @product INT, @count INT, @suplier INT, @orderNum INT, @date DATE
--		DECLARE returnProduct_cursor CURSOR LOCAL FOR
--		SELECT warehouseNumber, productCode, -productCount, NULL, orderNumber, @transactionDate
--		FROM ProductMovements
--		WHERE orderNumber = @order AND productCount<0
--		OPEN returnProduct_cursor
--		FETCH NEXT FROM returnProduct_cursor INTO @warehouse, @product, @count, @suplier, @orderNum, @date
--		WHILE @@FETCH_STATUS=0
--		BEGIN
--		INSERT INTO ProductMovements
--		VALUES (@warehouse, @product, @count, @suplier, @orderNum, @date)
--		FETCH NEXT FROM returnProduct_cursor INTO @warehouse, @product, @count, @suplier, @orderNum, @date
--		END
--		CLOSE returnProduct_cursor
--		DEALLOCATE returnProduct_cursor
--	END

--	IF @status = 10 -- статус "готов к выдаче"
--	BEGIN
--		UPDATE Orders
--	SET statusCode = @status, deliveryDate = @transactionDate
--	RETURN
--	END

--	UPDATE Orders
--	SET statusCode = @status, sum = @orderSum
--	WHERE number = @order