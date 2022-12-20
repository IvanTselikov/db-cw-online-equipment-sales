CREATE TRIGGER Tr_ProductCharacteristics_2
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