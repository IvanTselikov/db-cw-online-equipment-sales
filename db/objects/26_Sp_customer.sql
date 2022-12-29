USE OnlineEquipmentSales;
GO

-- представление с информацией о товаре
CREATE VIEW ProductsForCustomers
AS
  SELECT p.code [Код товара],
         p.[name] [Название товара],
         p.warranty [Гарантия],
         p.maxDiscountPercentage [Максимальная скидка],
         CONVERT(VARCHAR(30), p.retailPrice, 1) [Розничная цена, руб.],
         CONVERT(VARCHAR(30), p.wholesalePrice, 1) [Оптовая цена, руб.],
         p.wholesaleQuantity [Оптовое количество, шт.],
         pt.[name] [Тип товара],
         m.[name] [Производитель]
  FROM Products p JOIN ProductTypes pt ON p.productTypeCode = pt.code
    JOIN Makers m ON p.makerCode = m.code;
GO

CREATE PROCEDURE sp_FindProductByCharacteristic
  @typeCode SMALLINT, @characteristic SMALLINT, @value SQL_VARIANT
AS
  SELECT pfc.*
  FROM Products p JOIN ProductCharacteristics pc ON p.code = pc.productCode
    JOIN ProductsForCustomers pfc ON p.code  = pfc.[Код товара]
  WHERE p.productTypeCode = @typeCode
    AND pc.characteristicCode = @characteristic
    AND pc.characteristicValue = @value;
