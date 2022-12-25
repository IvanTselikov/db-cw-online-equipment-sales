USE OnlineEquipmentSales;
GO

CREATE TRIGGER tr_CheckCustomerBirthDate
ON Customers
INSTEAD OF UPDATE, INSERT 
AS
	DECLARE @dateOfB DATE	
	SELECT @dateOfB = dateOfBirth 
	FROM inserted

	IF @dateOfB >= CAST(GETDATE() AS DATE)
		RAISERROR('ƒата рождени€ должна быть меньше текущей даты', 16, 1)

	INSERT INTO Customers
	SELECT firstName, secondName, patronymic, dateOfBirth, phoneNumber, sex, email FROM inserted