USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_AvgSumOfCanceledOrders AS
	SELECT avg(sum) AS avgSumOfCanceledOrders
	FROM Orders
	WHERE statusCode = 12 -- "מעלום¸ם"
