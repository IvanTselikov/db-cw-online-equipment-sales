-- !!! ������� ProductCharacteristics, �������� ��� ������� characteristicValue �� sql_variant
CREATE TRIGGER Tr_ProductCharacteristics_3
ON ProductCharacteristics
INSTEAD OF INSERT, UPDATE
AS
  DECLARE @productCode INT,
          @characteristicCode SMALLINT,
          @characteristicValueRaw SQL_VARIANT,
          @characteristicValueConverted SQL_VARIANT,
          @dataTypeCode TINYINT;

  SELECT @productCode = productCode,
         @characteristicCode = characteristicCode,
         @characteristicValueRaw = characteristicValue
  FROM inserted;

  -- �������� ��� ���� ��������� ��������������
  SELECT @dataTypeCode = dataTypeCode
  FROM Characteristics
  WHERE code = @characteristicCode;

  -- �������� �������������� ��������� �������� �������������� � ������ ���
  BEGIN TRY
    IF @dataTypeCode = 1
      SET @characteristicValueConverted = TRY_CONVERT(VARCHAR(100), @characteristicValueRaw);
    ELSE IF @dataTypeCode = 2
      SET @characteristicValueConverted = TRY_CONVERT(VARCHAR(50), @characteristicValueRaw);
    ELSE IF @dataTypeCode = 3
      SET @characteristicValueConverted = TRY_CONVERT(REAL, @characteristicValueRaw);
    ELSE IF @dataTypeCode = 4
      SET @characteristicValueConverted = TRY_CONVERT(SMALLINT, @characteristicValueRaw);
    ELSE IF @dataTypeCode = 5
      SET @characteristicValueConverted = TRY_CONVERT(INT, @characteristicValueRaw);
  END TRY
  BEGIN CATCH
  END CATCH;

  -- ���� �� ������� �������������� - ������
  IF @characteristicValueConverted IS NULL
    RAISERROR('��������� �������� �������������� �� ������������� � ���� ������!', 16, 10);
  ELSE
  BEGIN
    IF (SELECT COUNT(*) FROM deleted) = 0 -- �������
      INSERT INTO ProductCharacteristics
      VALUES (@productCode, @characteristicCode, @characteristicValueConverted);
    ELSE -- ����������
      UPDATE ProductCharacteristics
      SET productCode = @productCode,
          characteristicCode = @characteristicCode,
          characteristicValue = @characteristicValueConverted
      WHERE productCode = (SELECT productCode FROM deleted)
        AND characteristicCode = (SELECT characteristicCode FROM deleted);
  END;
