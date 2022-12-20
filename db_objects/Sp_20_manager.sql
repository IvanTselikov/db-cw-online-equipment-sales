CREATE PROC sp_GetBoredCustomers
  @threshold DATETIME
AS
  SELECT *
  FROM Orders
  WHERE orderDate