USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_GetSalesPerType @dateStart DATE = '0001-01-01', @dateEnd DATE = '0001-01-01'
AS
	IF @dateEnd = '0001-01-01'
		SET @dateEnd = GETDATE()

	SELECT ProductTypes.name, -SUM(productCount) AS productCount, @dateStart AS periodStart, @dateEnd AS periodEnd
	FROM Orders JOIN ProductMovements ON Orders.number = ProductMovements.orderNumber
		JOIN Products ON   ProductMovements.productCode = Products.code 
		JOIN ProductTypes ON ProductTypes.code = Products.productTypeCode
	WHERE orderDate >= @dateStart AND orderDate <= @dateEnd AND statusCode = 11 -- только из полученных заказов
	GROUP BY ProductTypes.name