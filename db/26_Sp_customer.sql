USE OnlineEquipmentSales;
GO

CREATE PROCEDURE sp_FindProductByCharacteristic @characteristic INT, @value SQL_VARIANT
AS
  SELECT *
  FROM Products
  WHERE code IN (SELECT productCode
                 FROM ProductCharacteristics
                 WHERE characteristicCode = @characteristic
                   AND characteristicValue = @value)