USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_MaxRevenueMonth AS
	WITH OrderSumsPerMonth 
	AS (SELECT year, month, SUM(sum) revenuePerMonth
		FROM (
			SELECT sum, MONTH(deliveryDate) AS month, YEAR(deliveryDate) AS year
			FROM Orders
			WHERE statusCode=11) AS ordersSums -- статус "получен"
		GROUP BY month, year)

	SELECT month, year, revenuePerMonth
	FROM OrderSumsPerMonth
	WHERE revenuePerMonth = (SELECT MAX(revenuePerMonth) from OrderSumsPerMonth)