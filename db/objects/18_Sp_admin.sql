USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_GetUnclaimedWarehouses @dateStart DATE = '0001-01-01', @dateEnd DATE = '0001-01-01'
AS
	IF @dateEnd = '0001-01-01'
		SET @dateEnd = GETDATE()

	SELECT TOP 5 WITH TIES number, count(number) AS movementsCount
	FROM Warehouses JOIN ProductMovements ON warehouseNumber = number
	WHERE movementDate >= @dateStart AND movementDate <= @dateEnd
	GROUP BY number
	ORDER BY movementsCount
GO

--индексы (Поля с низкой селективностью. Скорее вред, чем польза)
CREATE INDEX IX_WarehauseNumber ON Warehouses (number)
CREATE INDEX IX_WarehauseNumber ON ProductMovements (warehouseNumber)