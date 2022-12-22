CREATE PROC sp_GetUnclaimedProducts
  @warehouseNumber SMALLINT,
  @threshold DATETIME -- не включительно
AS
  WITH productsInWarehouse AS
    (SELECT DISTINCT productCode
     FROM ProductMovements
     WHERE warehouseNumber = @warehouseNumber),
       ordersAfterThreshold AS
    (SELECT number
     FROM Orders
     WHERE orderDate > @threshold),
       movementsInWarehouse AS
    (SELECT productCode
     FROM ProductMovements pm JOIN ordersAfterThreshold oat
      ON pm.orderNumber = oat.number
     WHERE warehouseNumber = @warehouseNumber)
  SELECT piw.productCode
  FROM productsInWarehouse piw LEFT JOIN movementsInWarehouse miw
    ON piw.productCode = miw.productCode
  WHERE miw.productCode IS NULL;

-- ПРОВЕРКА
DECLARE @th DATETIME = DATEADD(d, -3, GETDATE());
EXEC sp_GetUnclaimedProducts 1, @th;

