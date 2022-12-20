-- ���� �������� �� ����� ���� ������ ���� ������
CREATE TRIGGER Tr_Orders_9
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


-- ����� �������� ����������� ��� ������������ ����� �������� ������� �� ������
CREATE TRIGGER Tr_ProductMovements_9
ON ProductMovements
AFTER INSERT, UPDATE
AS
  DECLARE @number INT, @sum MONEY, @orderDate DATETIME,
          @deliveryDate DATETIME, @employeeId SMALLINT,
          @pickupPointNumber SMALLINT, @statusCode TINYINT,
          @paymentMethodCode TINYINT, @customerId INT;

  SELECT @number = number, @sum = [sum], @orderDate = orderDate,
         @deliveryDate = deliveryDate, @employeeId = employeeId,
         @pickupPointNumber = pickupPointNumber, @statusCode = statusCode,
         @paymentMethodCode = paymentMethodCode, @customerId = customerId
  FROM inserted;

  IF DATEDIFF(s, @orderDate, @deliveryDate) < 0
    RAISERROR('���� �������� �� ����� ���� ������ ���� ������!', 16, 10);
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

    IF (SELECT COUNT(*) FROM deleted) = 0 -- �������
      INSERT INTO Orders
      VALUES (@sum, @orderDate, @deliveryDate, @employeeId,
              @pickupPointNumber, @statusCode, @paymentMethodCode, @customerId);
    ELSE -- ����������
      UPDATE Orders
      SET [sum] = @sum, orderDate = @orderDate,
          deliveryDate = @deliveryDate, employeeId = @employeeId,
          pickupPointNumber = @pickupPointNumber, statusCode = @statusCode,
          paymentMethodCode = @paymentMethodCode, customerId = @customerId
      WHERE number = (SELECT number FROM deleted);
  END;