USE OnlineEquipmentSales;
GO

-- ���� �������� �� ����� ���� ������ ���� ������
CREATE TRIGGER tr_ChechDeliveryDate
ON Orders
AFTER INSERT, UPDATE
AS
  DECLARE @orderDate DATETIME, @deliveryDate DATETIME;

  SELECT @orderDate = orderDate, @deliveryDate = deliveryDate
  FROM inserted;

  IF @deliveryDate IS NOT NULL AND DATEDIFF(s, @orderDate, @deliveryDate) < 0
  BEGIN
    RAISERROR('���� �������� �� ����� ���� ������ ���� ������!', 16, 10);
    ROLLBACK TRAN;
  END;
GO

-- ����� �������� ����������� ��� ������������ ����� �������� ������� �� ������
CREATE TRIGGER tr_CalcDeliveryDate
ON Orders
AFTER INSERT, UPDATE
AS
  DECLARE @number INT, @orderDate DATETIME, @deliveryDate DATETIME;

  SELECT @number = number, @orderDate = orderDate, @deliveryDate = deliveryDate
  FROM inserted;

  IF DATEDIFF(s, @orderDate, @deliveryDate) < 0
  BEGIN
    RAISERROR('���� �������� �� ����� ���� ������ ���� ������!', 16, 10);
    ROLLBACK TRAN;
  END;
  ELSE
  BEGIN
    IF @deliveryDate IS NULL -- ���� ���� �������� �� ������ ����, ��� �����������
                            -- �� ������-�������
    BEGIN
      -- ��������� ����� ����� ������������ ����� � ������
      DECLARE @daysLeft INT;
      SELECT @daysLeft = MAX(d.deliveryTime)
      FROM inserted i JOIN ProductMovements pm ON i.number = pm.orderNumber
        JOIN Deliveries d ON i.pickupPointNumber = d.pickupPointNumber
        AND pm.warehouseNumber = d.warehouseNumber
      WHERE orderNumber = @number;
      SET @deliveryDate = DATEADD(d, @daysLeft, @deliveryDate);
    END;

    UPDATE Orders
    SET deliveryDate = @deliveryDate
    WHERE number = (SELECT number FROM deleted);
  END;
