USE OnlineEquipmentSales;
GO

-- ���� �������� ����������� ��� ���� ������ + ����� ����� ���������� �������� ������,
-- ��������� � �����
CREATE TRIGGER tr_CalcDeliveryDate
ON ProductMovements
AFTER INSERT, UPDATE
AS
  DECLARE @number INT, @orderDate DATETIME, @deliveryDate DATETIME;

  SELECT @number = number, @orderDate = orderDate, @deliveryDate = deliveryDate
  FROM inserted i JOIN Orders o ON i.orderNumber = o.number;

  IF @deliveryDate IS NULL
  BEGIN
    -- ��������� ����� ����� ������������ ����� � ������
    DECLARE @daysLeft INT;
    SELECT @daysLeft = MAX(d.deliveryTime)
    FROM ProductMovements pm JOIN Orders o ON pm.orderNumber = o.number
      JOIN Deliveries d ON o.pickupPointNumber = d.pickupPointNumber
      AND pm.warehouseNumber = d.warehouseNumber
    WHERE pm.orderNumber = @number;
    SET @deliveryDate = DATEADD(dd, @daysLeft, @orderDate);

    UPDATE Orders
    SET deliveryDate = @deliveryDate
    WHERE number = @number;
  END;
GO

CREATE TRIGGER tr_CheckDeliveryDate
ON Orders
AFTER INSERT, UPDATE
AS
  DECLARE @number INT, @orderDate DATETIME, @deliveryDate DATETIME;

  SELECT @number = number, @orderDate = orderDate, @deliveryDate = deliveryDate
  FROM inserted;

  -- � ������ ��������� ���� ������ ����� ����������� � ���� ��������
  IF @orderDate <> (SELECT orderDate FROM deleted)
  BEGIN
    DECLARE @daysLeft INT;
    SELECT @daysLeft = MAX(d.deliveryTime)
    FROM inserted i JOIN ProductMovements pm ON i.number = pm.orderNumber
      JOIN Deliveries d ON i.pickupPointNumber = d.pickupPointNumber
      AND pm.warehouseNumber = d.warehouseNumber
    WHERE orderNumber = @number;
    SET @deliveryDate = DATEADD(d, @daysLeft, @orderDate);

    UPDATE Orders
    SET deliveryDate = @deliveryDate
    WHERE number = (SELECT number FROM deleted);
  END;
  ELSE IF @orderDate > @deliveryDate
  BEGIN
    RAISERROR('���� �������� �� ����� ���� ������ ���� ������!', 16, 10);
    ROLLBACK TRAN;
  END;
GO

