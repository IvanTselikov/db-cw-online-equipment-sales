USE OnlineEquipmentSales;
GO

CREATE PROC sp_GetAvgOrderSum
  @startDate DATETIME = NULL,
  @endDate DATETIME = NULL,
  @avgSum MONEY OUTPUT
AS
  IF @startDate IS NULL
    IF @endDate IS NULL
      SELECT @avgSum = AVG([sum]) -- ������� �� ���� �������
      FROM Orders;
    ELSE
      SELECT @avgSum = AVG([sum]) -- ������� �� ������� �� ��������� ����
      FROM Orders
      WHERE orderDate < @endDate;
  ELSE
    IF @endDate IS NULL
      SELECT @avgSum = AVG([sum]) -- ������� �� ������� ����� ��������� ����
      FROM Orders
      WHERE orderDate > @startDate;
    ELSE
      SELECT @avgSum = AVG([sum]) -- ������� �� ������� � ��������� ����������
      FROM Orders
      WHERE orderDate BETWEEN @startDate AND @endDate;

CREATE INDEX IX_Orders_orderDate
ON Orders (orderDate)
INCLUDE ([sum]);