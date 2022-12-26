USE OnlineEquipmentSales;
GO

CREATE PROC sp_GetBoredCustomers
  @threshold DATETIME
AS
  SELECT *
  FROM Customers c
  WHERE NOT EXISTS (SELECT * FROM Orders o WHERE c.id = o.customerId AND orderDate >= @threshold)
