--8 �� ��������
USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_CanceledOrderProducts ON Orders
INSTEAD OF UPDATE 
AS
	DECLARE @transactionDate DATE, @status TINYINT, @order INT, @orderSum MONEY;
	SET @transactionDate = GETDATE()
	
	SELECT @order = number, @status = statusCode, @orderSum = sum
	FROM inserted
	
	IF @status = 12 -- ������ "������
	BEGIN
		INSERT INTO ProductMovements
		SELECT warehouseNumber, productCode, -productCount, NULL, orderNumber, @transactionDate
		FROM ProductMovements
	END

	IF @status = 10 -- ������ "����� � ������"
	BEGIN
		UPDATE Orders
	SET statusCode = @status, deliveryDate = @transactionDate
	RETURN
	END

	UPDATE Orders
	SET statusCode = @status, sum = @orderSum