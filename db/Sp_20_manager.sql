USE OnlineEquipmentSales;
GO

CREATE PROC sp_GetBoredCustomers
  @threshold DATETIME
AS
  SELECT *
  FROM Customers
  WHERE NOT EXISTS (SELECT * FROM Orders WHERE orderDate >= @threshold);
