USE OnlineEquipmentSales;
GO

CREATE PROC sp_CancelOrder
  @orderNumber INT
AS
  DECLARE @currentOrderStatus TINYINT;
  SELECT @currentOrderStatus = statusCode
  FROM Orders
  WHERE number = @orderNumber;
  IF @currentOrderStatus IS NULL
  BEGIN
    RAISERROR('����� �� ����������!', 16, 10);
    RETURN 1;
  END;
  ELSE IF @currentOrderStatus IN (10, 11, 12)
  BEGIN
    RAISERROR('������ �������� ���������� ����� ��� �����, ������� � ������!', 16, 10);
    RETURN 1;
  END;
  ELSE IF @currentOrderStatus NOT IN (SELECT code FROM OrderStatuses)
  BEGIN
    RAISERROR('��������� ������ �� ����������!', 16, 10);
    RETURN 1;
  END;
  UPDATE Orders
  SET statusCode = @currentOrderStatus
  WHERE number = @orderNumber;