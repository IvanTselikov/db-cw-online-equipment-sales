USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_CheckCharacteristicTypeCompliance 
ON ProductCharacteristics
AFTER INSERT, UPDATE
AS
  DECLARE @typeCode SMALLINT,
          @characteristicCode SMALLINT,
          @productCode INT;

  -- ������� ��� ������, �������������� ��� �������� ������� ������������
  SELECT @typeCode = productTypeCode
  FROM inserted i JOIN Products p
    ON i.productCode = p.code;

  -- ��������� ��������������, ������� ������� ������������
  SELECT @characteristicCode = characteristicCode
  FROM inserted;

  WHILE @typeCode IS NOT NULL
  BEGIN
    -- ���� ����������� �������������� ������������� ���� ������ ��� ������
    -- �� "�������" ���� ������, �������� ���� ���������
    IF EXISTS (
      SELECT characteristicCode
      FROM ProductTypeCharacteristics
      WHERE productTypeCode = @typeCode
        AND characteristicCode = @characteristicCode
    )
      RETURN;
    SELECT @typeCode = parentTypeCode
    FROM ProductTypes
    WHERE code = @typeCode;
  END

  -- ����������� �������������� �� ������������� �� ���� ������, �� "�������" ����
  RAISERROR('���������� ��������/�������� �������������� ��� ������, �.�. ��� �� ������������� ���� ������� ������.', 16, 10);
  ROLLBACK TRAN;
GO

-- ��������
--SELECT pt.name [���]
--FROM Products p JOIN ProductTypes pt ON p.productTypeCode = pt.code
--WHERE p.code = 11;

--SELECT name [���]
--FROM Characteristics
--WHERE code = 15;

--INSERT INTO ProductCharacteristics
--VALUES (11, 15, 4);
