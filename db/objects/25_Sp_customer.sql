USE OnlineEquipmentSales;
GO

-- ����������

-- ������ ������������� ��� ����������� ������� ��� ��������
CREATE VIEW OrdersForCustomers
AS
  SELECT o.number [����� ������],
         CONVERT(VARCHAR(30), o.[sum], 1) [�����, ���.],
         CONVERT(VARCHAR(25), o.orderDate, 120) [���� ������],
         CONVERT(VARCHAR(10), o.deliveryDate, 120) [���� ��������],
         e.secondName + ' ' + e.firstName [��������],
         e.phoneNumber [������� ���������],
         c.[name] + ', ' + a.street + ', ' + a.building [����� ������],
         os.[name] [������],
         pm.[name] [������ ������],
         o.customerId [id �������],
         o.discountPrc [������, %]
  FROM Orders o LEFT JOIN Employees e ON o.employeeId = e.id
    JOIN PickupPoints pp ON o.pickupPointNumber = pp.number
    JOIN Addresses a ON pp.addressId = a.id
    JOIN Communities c ON a.communityCode = c.code
    JOIN OrderStatuses os ON o.statusCode = os.code
    JOIN PaymentMethods pm ON o.paymentMethodCode = pm.code;
GO

-- ���������

CREATE PROC sp_CustomerOrders
  @customerId INT,
  @dateStart DATETIME = NULL,
  @dateEnd DATETIME = NULL
AS
  IF @dateStart IS NULL
    SET @dateStart = (SELECT DATEDIFF(dd, 1, MIN(orderDate)) FROM Orders);
  IF @dateEnd IS NULL
    SET @dateEnd = GETDATE();
  IF @dateStart = @dateEnd -- ������ ������ �� ��������� ����
    SET @dateEnd = DATEADD(dd, 1, @dateEnd);
  IF @dateEnd < @dateStart
  BEGIN
    RAISERROR('���� ����� ���������������� ��������� �� ����� ���� ������ ���� ������!', 16, 10);
    RETURN;
  END;
  SELECT [����� ������], [�����, ���.], [���� ������],
         [���� ��������], [��������], [������� ���������],
         [����� ������], [������], [������ ������], [������, %]
  FROM OrdersForCustomers
  WHERE [id �������] = @customerId
    AND CONVERT(DATETIME, [���� ������], 120) >= @dateStart
    AND CONVERT(DATETIME, [���� ������], 120) <= @dateEnd;
GO

-- ��������
--DECLARE @customerId INT = 4,
--        @start DATETIME = CONVERT(DATETIME, '15.01.2022', 104),
--        @end DATETIME = CONVERT(DATETIME, '21.12.2022', 104);

--EXEC sp_CustomerOrders @customerId, @start, @end;
--GO
