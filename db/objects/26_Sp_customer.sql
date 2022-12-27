USE OnlineEquipmentSales;
GO

ALTER PROCEDURE sp_FindProductByCharacteristic
  @typeCode SMALLINT, @characteristic SMALLINT, @value SQL_VARIANT
AS
  SELECT pfc.*
  FROM Products p JOIN ProductCharacteristics pc ON p.code = pc.productCode
    JOIN ProductsForCustomers pfc ON p.code  = pfc.[Код товара]
  WHERE p.productTypeCode = @typeCode
    AND pc.characteristicCode = @characteristic
    AND pc.characteristicValue = @value;
