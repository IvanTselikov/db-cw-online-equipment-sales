USE OnlineEquipmentSales;
GO

-- ПОДГОТОВКА

-- создаём представление для отображения заказов для клиентов
CREATE VIEW OrdersForCustomers
AS
  SELECT o.number [Номер заказа],
         CONVERT(VARCHAR(30), o.[sum], 1) [Сумма, руб.],
         CONVERT(VARCHAR(25), o.orderDate, 120) [Дата заказа],
         CONVERT(VARCHAR(10), o.deliveryDate, 120) [Дата доставки],
         e.secondName + ' ' + e.firstName [Менеджер],
         e.phoneNumber [Телефон менеджера],
         c.[name] + ', ' + a.street + ', ' + a.building [Пункт выдачи],
         os.[name] [Статус],
         pm.[name] [Способ оплаты],
         o.customerId [id клиента],
         o.discountPrc [Скидка, %]
  FROM Orders o LEFT JOIN Employees e ON o.employeeId = e.id
    JOIN PickupPoints pp ON o.pickupPointNumber = pp.number
    JOIN Addresses a ON pp.addressId = a.id
    JOIN Communities c ON a.communityCode = c.code
    JOIN OrderStatuses os ON o.statusCode = os.code
    JOIN PaymentMethods pm ON o.paymentMethodCode = pm.code;
GO

-- ПРОЦЕДУРА

CREATE PROC sp_CustomerOrders
  @customerId INT,
  @dateStart DATETIME = NULL,
  @dateEnd DATETIME = NULL
AS
  IF @dateStart IS NULL
    SET @dateStart = (SELECT DATEDIFF(dd, 1, MIN(orderDate)) FROM Orders);
  IF @dateEnd IS NULL
    SET @dateEnd = GETDATE();
  IF @dateStart = @dateEnd -- заказы только за указанный день
    SET @dateEnd = DATEADD(dd, 1, @dateEnd);
  IF @dateEnd < @dateStart
  BEGIN
    RAISERROR('Дата конца рассматриваемого интервала не может быть меньше даты начала!', 16, 10);
    RETURN;
  END;
  SELECT [Номер заказа], [Сумма, руб.], [Дата заказа],
         [Дата доставки], [Менеджер], [Телефон менеджера],
         [Пункт выдачи], [Статус], [Способ оплаты], [Скидка, %]
  FROM OrdersForCustomers
  WHERE [id клиента] = @customerId
    AND CONVERT(DATETIME, [Дата заказа], 120) >= @dateStart
    AND CONVERT(DATETIME, [Дата заказа], 120) <= @dateEnd;
GO

-- проверка
--DECLARE @customerId INT = 4,
--        @start DATETIME = CONVERT(DATETIME, '15.01.2022', 104),
--        @end DATETIME = CONVERT(DATETIME, '21.12.2022', 104);

--EXEC sp_CustomerOrders @customerId, @start, @end;
--GO
