USE OnlineEquipmentSales;
SET NOCOUNT ON;
GO

-- создаём таблицу для сопоставления пользователя БД
-- и клиента интернет-магазина
CREATE TABLE CustomersRegister(
  username SYSNAME NOT NULL,
  customerId INT NOT NULL,
  CONSTRAINT PK_CustomersRegister PRIMARY KEY (username, customerId),
  CONSTRAINT FK_CustomersRegister_customerId FOREIGN KEY (customerId)
    REFERENCES Customers(id)
);
GO

INSERT INTO CustomersRegister
VALUES ('Customer', 4);
GO

-- создаём ХП для доступа к регистру клиентов и устанавливаем разрешение
-- на запуск
CREATE PROC sp_GetCustomerId
  @username SYSNAME,
  @customerId INT OUTPUT
AS
  SELECT @customerId = customerId
  FROM CustomersRegister;
GO

GRANT EXECUTE ON sp_GetCustomerId TO Customer;
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

GRANT EXECUTE ON sp_GetOrderProducts TO Customer;
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
