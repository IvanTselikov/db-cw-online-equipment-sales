USE OnlineEquipmentSales;
GO

CREATE PROC sp_GetWarehouseAvgWorkload
  @warehouseNumber SMALLINT,
  @startDate DATETIME = NULL,
  @endDate DATETIME = NULL,
  @avgWorkload FLOAT OUTPUT
AS
  IF @startDate IS NULL -- измеряем загруженность склада с самого первого движения
    SELECT @startDate = MIN(movementDate)
    FROM ProductMovements
    WHERE warehouseNumber = @warehouseNumber;
  IF @endDate IS NULL -- измеряем загруженность склада до самого последнего движения
    SELECT @startDate = MAX(movementDate)
    FROM ProductMovements
    WHERE warehouseNumber = @warehouseNumber;
  -- считаем загрузку склада в каждый день интервала
  WITH dates AS
    (SELECT @startDate dt
     UNION ALL
     SELECT DATEADD(d, 1, @startDate) FROM dates
     WHERE @startDate < @endDate),
       wload AS
    (SELECT SUM(productCount) wload
     FROM dates LEFT JOIN ProductMovements pm ON pm.movementDate <= dates.dt
     WHERE warehouseNumber = @warehouseNumber)
  SELECT @avgWorkload = AVG(wload * 1.0)
  FROM wload;

CREATE INDEX IX_ProductMovements_warehouseNumber
ON ProductMovements (warehouseNumber, movementDate);