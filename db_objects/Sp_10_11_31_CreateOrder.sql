CREATE TYPE ProductCount
AS TABLE(productCode INT, productCount INT);

CREATE PROC sp_CreateOrder
  @customerId INT,
  @pickupPointNumber SMALLINT,
  @paymentMethodCode TINYINT,
  @products AS ProductCount READONLY,
  @deliveryDate DATETIME = NULL,
  @employeeId SMALLINT = NULL
AS
  SET NOCOUNT ON;

  -- проверка аргументов
  IF @customerId NOT IN (SELECT id FROM Customers)
    RAISERROR('Указанного клиента не существует!', 16, 10);
  ELSE IF @pickupPointNumber NOT IN (SELECT number FROM PickupPoints)
    RAISERROR('Указанного пункта выдачи не существует!', 16, 10);
  ELSE IF @paymentMethodCode NOT IN (SELECT code FROM PaymentMethods)
    RAISERROR('Указанного способа оплаты не существует!', 16, 10);
  ELSE IF NOT EXISTS (SELECT * FROM @products)
    RAISERROR('Укажите товары для покупки!', 16, 10);
  ELSE
  BEGIN
      -- временная таблица для движений товаров на складах,
    -- будут добавлены в основную таблицу в случае успешного
    -- создания заказа
    DECLARE @movements TABLE(warehouseNumber SMALLINT,
                             productCode INT,
                             productCount INT,
                             supplierCode SMALLINT,
                             orderNumber INT,
                             movementDate DATETIME);
    DECLARE @productCode INT,
            @productCount INT,
            @orderDate DATETIME = GETDATE(),
            @error BIT = 0;

    -- перебираем каждый из указанных товаров
    DECLARE crsr CURSOR FOR
    SELECT * FROM @products;

    OPEN crsr;

    FETCH NEXT FROM crsr INTO @productCode, @productCount;

    WHILE @@FETCH_STATUS = 0
      BEGIN
        DECLARE @warehouseNumber SMALLINT, @deliveryTime SMALLINT;

        -- перебираем каждый из доступных складов
        -- (те, из которых есть доставка в указанный пункт выдачи),
        -- в первую очередь - самые близкие склады
        DECLARE crsr1 CURSOR FOR
        SELECT warehouseNumber, deliveryTime
        FROM Deliveries
        WHERE pickupPointNumber = @pickupPointNumber
        ORDER BY deliveryTime;

        OPEN crsr1;

        FETCH NEXT FROM crsr1 INTO @warehouseNumber, @deliveryTime;

        WHILE @@FETCH_STATUS = 0
          BEGIN
            -- считаем количество данного товара на данном складе
            DECLARE @pcWarehouse INT;

            SELECT @pcWarehouse = SUM(productCount)
            FROM ProductMovements
            WHERE productCode = @productCode AND warehouseNumber = @warehouseNumber;

            IF @pcWarehouse > 0
              BEGIN
                -- забираем со склада нужное (или максимально возможное)
                -- количество товара
                DECLARE @pcMovement INT = CASE WHEN @pcWarehouse > @productCount
                  THEN @productCount ELSE @pcWarehouse END;

                INSERT INTO @movements
                VALUES (@warehouseNumber,
                        @productCode,
                        @pcMovement * -1,
                        NULL,
                        NULL,
                        @orderDate);

                SET @productCount = @productCount - @pcMovement;
              END;

            IF @productCount = 0
              BREAK;

            FETCH NEXT FROM crsr1 INTO @warehouseNumber, @deliveryTime;
          END;

        CLOSE crsr1;
        DEALLOCATE crsr1;

        IF @productCount > 0 -- на складах недостаточно товаров
          BEGIN
            DECLARE @productName NVARCHAR(300);
            SELECT @productName = [name] FROM Products p WHERE p.code = @productCode;
            DECLARE @mes NVARCHAR(350) = 'На складах не хватает товара ' + @productName + '!';
            RAISERROR(@mes, 16, 10);
            SET @error = 1;
          END;

        FETCH NEXT FROM crsr INTO @productCode, @productCount;
      END;

    CLOSE crsr;
    DEALLOCATE crsr;

    IF @error = 0 -- корзина успешно собрана
      BEGIN
        -- создаём заказ
        INSERT INTO Orders
        VALUES(0, @orderDate, NULL, @employeeId, @pickupPointNumber,
                8, @paymentMethodCode, @customerId);

        -- получаем номер созданного заказа
        DECLARE @orderNumber INT;
        SELECT TOP(1) @orderNumber = number
        FROM Orders
        ORDER BY number DESC;

        -- указываем номер заказа в движениях
        UPDATE @movements
        SET orderNumber = @orderNumber;

        -- фиксируем движения в БД
        INSERT INTO ProductMovements
        SELECT * FROM @movements;
      END;

    RETURN @error; -- 0 - успешное добавление, иначе - 1
  END;
  RETURN 1;
  
-- ПРОВЕРКА
DECLARE @products AS ProductCount; -- табличная переменная для хранения товаров,
                                   -- которые нужно купить в рамках заказа
INSERT INTO @products
SELECT 1, 20 -- 20 товаров с кодом 1
UNION
SELECT 2, 1 -- 1 товар с кодом 2
UNION
SELECT 4, 3; -- 4 товара с кодом 3

EXEC sp_CreateOrder 1, 3, 1, @products -- вызов ХП для совершения заказа
