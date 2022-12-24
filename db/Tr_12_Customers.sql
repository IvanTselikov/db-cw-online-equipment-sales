--12
USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_CanceledOrderProducts
ON Customers
INSTEAD OF UPDATE, INSERT 
AS
	DECLARE @dateOfB DATE	
	SELECT @dateOfB = dateOfBirth 
	FROM inserted

	IF @dateOfB >= CAST(GETDATE() AS DATE)
		RAISERROR('���� �������� ������ ���� ������ ������� ����', 16, 1)

	INSERT INTO Customers
	SELECT firstName, secondName, patronymic, dateOfBirth, phoneNumber, sex, email, discountPercentage FROM inserted