USE OnlineEquipmentSales;
GO

CREATE TRIGGER tr_CheckCustomerBirthDate
ON Customers
AFTER UPDATE, INSERT 
AS
	DECLARE @dateOfB DATE	
	SELECT @dateOfB = dateOfBirth 
	FROM inserted

	IF @dateOfB >= CAST(GETDATE() AS DATE)
	BEGIN
		RAISERROR('ƒата рождени€ должна быть меньше текущей даты', 16, 1);
		ROLLBACK TRAN;
	END
