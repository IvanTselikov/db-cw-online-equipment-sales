USE OnlineEquipmentSales;
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