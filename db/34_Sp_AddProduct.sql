USE OnlineEquipmentSales;
GO

CREATE TYPE NewProductCharacteristics
AS TABLE (characteristicCode INT, value SQL_VARIANT);
GO

CREATE PROCEDURE sp_AddProduct
  @name NVARCHAR(300), @warranty SMALLINT, @maxDiscount TINYINT, 
  @retPrice MONEY, @wsPrice MONEY, @wsCount INT, @typeCode SMALLINT,
  @maker SMALLINT, @newCharacteristics AS NewProductCharacteristics READONLY
AS
	INSERT INTO Products
	VALUES (@name, @warranty, @maxDiscount, @retPrice, @wsPrice, @wsCount, @typeCode, @maker)

	DECLARE @newProductCode INT
	SELECT TOP 1 @newProductCode = code
	FROM Products
	ORDER BY code DESC

	INSERT INTO ProductCharacteristics
	SELECT @newProductCode, characteristicCode,  value
	FROM  @newCharacteristics
GO

-- ПРОВЕРКА
--DECLARE @prodChar AS NewProductCharacteristics

--INSERT INTO @prodChar -- заполняем характеристики
--SELECT 1, 5
--UNION
--SELECT 2, 15
--UNION
--SELECT 3, 20
--UNION
--SELECT 4, 30

--EXEC sp_AddProduct "ТоварТест", 6, 15, 150, 100, 15, 9, 4, @prodChar -- добавляем товар
