USE OnlineEquipmentSales;
SET NOCOUNT ON;
GO

-- представление с содержимым заказов (товар - количество - скидка)
CREATE VIEW OrderProducts
AS
  SELECT o.number [Номер заказа],
         p.[name] [Название товара],
         pt.[name] [Тип товара],
         -pm.productCount [Количество, шт.],
         CASE WHEN o.discountPrc <= p.maxDiscountPercentage THEN o.discountPrc
           ELSE p.maxDiscountPercentage END [Скидка, %]
  FROM ProductMovements pm JOIN Products p ON pm.productCode = p.code
    JOIN ProductTypes pt ON p.productTypeCode = pt.code
    JOIN Orders o ON pm.orderNumber = o.number
  WHERE productCount < 0;
GO

-- ХП для доступа к представлению
CREATE PROC sp_GetOrderProducts
  @orderNumber INT = NULL
AS
  SELECT [Название товара], [Тип товара], [Количество, шт.], [Скидка, %]
  FROM OrderProducts
  WHERE [Номер заказа] = @orderNumber;
GO

GRANT EXECUTE ON sp_GetOrderProducts TO Customer; -- ХП для доступа к представлению с содержимым заказов
GO

-- создание заказов
-- №1
DECLARE @products AS ProductCount;
INSERT INTO @products
SELECT 1, 3
UNION ALL
SELECT 2, 1
UNION ALL
SELECT 3, 2;
EXEC sp_CreateOrder 4, 3, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2021-02-18 00:06:51.193', 102),
    employeeId = 1,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №2
DELETE FROM @products;
INSERT INTO @products
SELECT 3, 1
UNION ALL
SELECT 4, 1 
UNION ALL
SELECT 5, 5;
EXEC sp_CreateOrder 4, 4, 2, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-12-01 00:06:35.863', 102),
    employeeId = 6,
    statusCode = 12
WHERE number = (SELECT MAX(number) FROM Orders);

-- №3
DELETE FROM @products;
INSERT INTO @products
SELECT 7, 2
UNION ALL
SELECT 8, 2
UNION ALL
SELECT 1, 5;
EXEC sp_CreateOrder 4, 3, 2, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2021-04-04 00:07:05.593', 102),
    employeeId = 6,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №4
DELETE FROM @products;
INSERT INTO @products
SELECT 9, 1
--UNION ALL
--SELECT 8, 2
--UNION ALL
--SELECT 1, 5;
EXEC sp_CreateOrder 4, 3, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2021-11-26 00:08:04.210', 102),
    employeeId = 1,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №5
DELETE FROM @products;
INSERT INTO @products
SELECT 11, 3
UNION ALL
SELECT 2, 3
--UNION ALL
--SELECT 1, 5;
EXEC sp_CreateOrder 4, 4, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-01-22 00:08:35.980', 102),
    employeeId = 2,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №6
DELETE FROM @products;
INSERT INTO @products
SELECT 11, 1
UNION ALL
SELECT 2, 1
UNION ALL
SELECT 1, 1;
EXEC sp_CreateOrder 4, 3, 2, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-02-13 00:16:40.110', 102),
    employeeId = 3,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №7
DELETE FROM @products;
INSERT INTO @products
SELECT 6, 2
--UNION ALL
--SELECT 2, 1
--UNION ALL
--SELECT 1, 1;
EXEC sp_CreateOrder 4, 4, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-03-06 00:17:09.540', 102),
    employeeId = 4,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);

-- №8
DELETE FROM @products;
INSERT INTO @products
SELECT 5, 1
UNION ALL
SELECT 9, 1
--UNION ALL
--SELECT 1, 1;
EXEC sp_CreateOrder 4, 3, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-12-22 00:17:34.183', 102),
    employeeId = 4,
    statusCode = 9
WHERE number = (SELECT MAX(number) FROM Orders);

-- №9
DELETE FROM @products;
INSERT INTO @products
SELECT 1, 1
EXEC sp_CreateOrder 4, 3, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-06-07 00:19:07.363', 102),
    employeeId = 4,
    statusCode = 12
WHERE number = (SELECT MAX(number) FROM Orders);

-- №10
DELETE FROM @products;
INSERT INTO @products
SELECT 2, 3
EXEC sp_CreateOrder 4, 4, 1, @products
UPDATE Orders
SET orderDate = CONVERT(DATETIME, '2022-10-10 00:19:19.673', 102),
    employeeId = 3,
    statusCode = 11
WHERE number = (SELECT MAX(number) FROM Orders);
GO

-- ХП для получения списка всех типов товаров
CREATE PROC sp_GetProductTypes
AS
  SELECT code [Код типа], [name] [Название типа]
  FROM ProductTypes;
GO

GRANT EXECUTE ON sp_GetProductTypes TO Customer;
GO

-- ХП для получения списка всех названий товаров указанного типа
CREATE PROC sp_GetProductsOfType
  @typeCode SMALLINT = NULL
AS
  IF @typeCode IS NULL OR @typeCode = 9 -- "Товар", обобщающий тип
    SELECT code, [name]
    FROM Products;
  ELSE
    SELECT code, [name]
    FROM Products
    WHERE productTypeCode = @typeCode;
GO

GRANT EXECUTE ON sp_GetProductsOfType TO Customer;
GO

-- ХП для получения адресов всех пунктов выдачи
CREATE PROC sp_GetPickupPointsAddresses
AS
  SELECT pp.number, c.[name] + ', ' + a.street + ', ' + a.building ppAddress
  FROM PickupPoints pp JOIN Addresses a ON pp.addressId = a.id
    JOIN Communities c ON a.communityCode = c.code;
GO

GRANT EXECUTE ON sp_GetPickupPointsAddresses TO Customer;
GO

-- ХП для получения названий способов оплаты
CREATE PROC sp_GetPaymentMethods
AS
  SELECT code, [name]
  FROM PaymentMethods;
GO

GRANT EXECUTE ON sp_GetPaymentMethods TO Customer;
GO

-- ХП для получения количества товаров на складах, из которых доступна доставка
-- в указанный пункт выдачи
CREATE PROC sp_GetPickupPointProductCount
  @productCode INT,
  @pickupPointNumber SMALLINT = NULL, -- по умолчанию - на всех ПВ
  @productCount INT OUTPUT
AS
  IF @pickupPointNumber IS NULL
    SELECT @productCount = SUM(productCount)
    FROM ProductMovements
    WHERE productCode = @productCode;
  ELSE
    SELECT @productCount = SUM(productCount)
    FROM ProductMovements
    WHERE productCode = @productCode AND warehouseNumber IN
      (SELECT DISTINCT warehouseNumber
       FROM Deliveries
       WHERE pickupPointNumber = @pickupPointNumber);
  IF @productCount IS NULL
    SET @productCount = 0;
GO

GRANT EXECUTE ON sp_GetPickupPointProductCount TO Customer;
GO

CREATE PROC sp_GetDefaultProductType
  @productTypeCode SMALLINT OUTPUT 
AS
  SELECT @productTypeCode = code
  FROM ProductTypes
  WHERE [name] = 'Товар';
GO

GRANT EXECUTE ON sp_GetDefaultProductType TO Customer;
GO

-- ХП для получения названия типа указанного товара
CREATE PROC sp_GetTypeOfProduct
  @productCode INT,
  @typeName NVARCHAR(300) OUTPUT
AS
  SELECT @typeName = pt.[name]
  FROM Products p JOIN ProductTypes pt ON p.productTypeCode = pt.code
  WHERE p.code = @productCode;
GO

GRANT EXECUTE ON sp_GetTypeOfProduct TO Customer;
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

-- ХП для доступа к этому представлению
CREATE PROC sp_GetProductInfo
  @productCode INT
AS
  SELECT *
  FROM ProductsForCustomers
  WHERE [Код товара] = @productCode;
GO

GRANT EXECUTE ON sp_GetProductInfo TO Customer;
GO

-- ХП для получения цены, скидки и стоимости товара
CREATE PROC sp_GetProductOrderInfo
  @productCode INT,
  @productCount INT,
  @orderDiscount TINYINT,
  @productPrice MONEY OUTPUT,
  @productDiscount TINYINT OUTPUT
AS
  SELECT @productPrice = CASE
    WHEN @productCount >= wholesaleQuantity THEN wholesalePrice
    ELSE retailPrice END,
         @productDiscount = CASE
    WHEN @orderDiscount > maxDiscountPercentage THEN maxDiscountPercentage
    ELSE @orderDiscount END
  FROM Products;
GO

GRANT EXECUTE ON sp_GetProductOrderInfo TO Customer;
GO

-- ХП для получения всех характеристик указанного типа
CREATE PROC sp_GetCharacteristicsOfType
  @typeCode SMALLINT
AS
  DECLARE @characteristics AS TABLE(
    code SMALLINT,
    [name] NVARCHAR(100)
  );
  WHILE @typeCode IS NOT NULL
  BEGIN
    INSERT INTO @characteristics
    SELECT c.code, c.[name] + ', ' + u.[name]
    FROM ProductTypeCharacteristics ptc JOIN Characteristics c
      ON ptc.characteristicCode = c.code
      JOIN Units u ON c.unitCode = u.code
    WHERE productTypeCode = @typeCode;

    SELECT @typeCode = parentTypeCode
    FROM ProductTypes
    WHERE code = @typeCode;
  END;
  SELECT *
  FROM @characteristics;
GO

GRANT EXECUTE ON sp_GetCharacteristicsOfType TO Customer;
GO

CREATE PROC sp_GetCharacteristicDataType
  @characteristicCode SMALLINT,
  @dataTypeCode TINYINT OUTPUT
AS
  SELECT @dataTypeCode = dataTypeCode
  FROM Characteristics
  WHERE code = @characteristicCode;
GO

GRANT EXECUTE ON sp_GetCharacteristicDataType TO Customer;
GO

-- разрешение на выполнение ХП для вычисления скидки покупателя
GRANT EXECUTE ON sp_GetCustomerDiscount TO Customer;
GO