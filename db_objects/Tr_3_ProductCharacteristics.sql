-- !!! таблица ProductCharacteristics, помен€ть тип столбца characteristicValue на sql_variant
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

  -- получаем код типа указанной характеристики
  SELECT @dataTypeCode = dataTypeCode
  FROM Characteristics
  WHERE code = @characteristicCode;

  -- пытаемс€ конвертировать указанное значение характеристики в нужный тип
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

  -- если не удалось конвертировать - ошибка
  IF @characteristicValueConverted IS NULL
    RAISERROR('”казанное значение характеристики не соответствует еЄ типу данных!', 16, 10);
  ELSE
  BEGIN
    IF (SELECT COUNT(*) FROM deleted) = 0 -- вставка
      INSERT INTO ProductCharacteristics
      VALUES (@productCode, @characteristicCode, @characteristicValueConverted);
    ELSE -- обновление
      UPDATE ProductCharacteristics
      SET productCode = @productCode,
          characteristicCode = @characteristicCode,
          characteristicValue = @characteristicValueConverted
      WHERE productCode = (SELECT productCode FROM deleted)
        AND characteristicCode = (SELECT characteristicCode FROM deleted);
  END;
