USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_AddProduct @name NVARCHAR(300), @warranty SMALLINT, @maxDiscount TINYINT, 
@retPrice MONEY, @wsPrice MONEY, @wsCount INT, @typeCode SMALLINT, @maker SMALLINT
AS
	INSERT INTO Products
	VALUES (@name, @warranty, @maxDiscount, @retPrice, @wsPrice, @wsCount, @typeCode, @maker);
GO

---
CREATE PROCEDURE sp_AddCharacteristicValue @product INT, @characteristic INT, @value SQL_VARIANT
AS
	INSERT INTO ProductCharacteristics
	VALUES (@product, @characteristic, @value);
GO
---
