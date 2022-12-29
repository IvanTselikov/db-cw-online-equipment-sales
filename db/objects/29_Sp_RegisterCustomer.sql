USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_AddCustomer @fName NVARCHAR(50), @sName NVARCHAR(50), @patronymic NVARCHAR(50) = NULL, 
@dateOfBirth DATE = NULL, @phone varchar(20) = NULL, @sex TINYINT = 0, @email NVARCHAR(320)
AS
	INSERT INTO Customers
	VALUES (@fName, @sName, @patronymic, @dateOfBirth, @phone, @sex, @email)
GO

CREATE UNIQUE INDEX ix_EmailUnique ON Customers (email)