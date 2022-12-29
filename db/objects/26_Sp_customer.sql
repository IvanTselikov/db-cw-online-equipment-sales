USE OnlineEquipmentSales;
GO

-- ������������� � ����������� � ������
CREATE VIEW ProductsForCustomers
AS
  SELECT p.code [��� ������],
         p.[name] [�������� ������],
         p.warranty [��������],
         p.maxDiscountPercentage [������������ ������],
         CONVERT(VARCHAR(30), p.retailPrice, 1) [��������� ����, ���.],
         CONVERT(VARCHAR(30), p.wholesalePrice, 1) [������� ����, ���.],
         p.wholesaleQuantity [������� ����������, ��.],
         pt.[name] [��� ������],
         m.[name] [�������������]
  FROM Products p JOIN ProductTypes pt ON p.productTypeCode = pt.code
    JOIN Makers m ON p.makerCode = m.code;
GO

CREATE PROCEDURE sp_FindProductByCharacteristic
  @typeCode SMALLINT, @characteristic SMALLINT, @value SQL_VARIANT
AS
  SELECT pfc.*
  FROM Products p JOIN ProductCharacteristics pc ON p.code = pc.productCode
    JOIN ProductsForCustomers pfc ON p.code  = pfc.[��� ������]
  WHERE p.productTypeCode = @typeCode
    AND pc.characteristicCode = @characteristic
    AND pc.characteristicValue = @value;
