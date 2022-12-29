USE OnlineEquipmentSales
SET NOCOUNT ON;
GO

-- ПОДГОТОВКА

-- меняем тип столбца characteristicValue таблицы ProductCharacteristics с nvarchar на sql_variant;
-- перед этим очищаем таблицу, предварительно сохранив данные из неё в копию
CREATE TABLE CopyTable(
  productCode INT,
  characteristicCode SMALLINT,
  characteristicValue NVARCHAR(MAX)
);
INSERT INTO CopyTable
SELECT productCode, characteristicCode, characteristicValue
FROM ProductCharacteristics;

-- замена разделителя с запятой на точку для корректной вставки
UPDATE CopyTable
SET characteristicValue = REPLACE(characteristicValue, ',', '.')
WHERE REPLACE(characteristicValue, ',', '') NOT LIKE '%[^0-9]%'
  AND LEN(characteristicValue) - LEN(REPLACE(characteristicValue, ',', '')) = 1
  AND CHARINDEX(',', characteristicValue) <> 1;

DELETE FROM ProductCharacteristics;

ALTER TABLE ProductCharacteristics
DROP COLUMN characteristicValue;

ALTER TABLE ProductCharacteristics
ADD characteristicValue SQL_VARIANT NOT NULL;
GO

-- ТРИГГЕР

-- триггер для конвертации типов
CREATE TRIGGER tr_ConvertProductCharacteristicType
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

  -- пытаемся конвертировать указанное значение характеристики в нужный тип
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
    RAISERROR('Указанное значение характеристики не соответствует её типу данных!', 16, 10);
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
GO

-- возвращаем данные
DECLARE crsr CURSOR FOR
  SELECT productCode, characteristicCode, CONVERT(SQL_VARIANT, CONVERT(VARCHAR(8000), characteristicValue))
  FROM CopyTable;

DECLARE @productCode INT, @characteristicCode SMALLINT, @characteristicValue SQL_VARIANT;

OPEN crsr;
FETCH NEXT FROM crsr INTO @productCode, @characteristicCode, @characteristicValue;
WHILE @@FETCH_STATUS = 0
BEGIN
  INSERT INTO ProductCharacteristics
  VALUES (@productCode, @characteristicCode, @characteristicValue);
  FETCH NEXT FROM crsr INTO @productCode, @characteristicCode, @characteristicValue;
END;

CLOSE crsr;
DEALLOCATE crsr;

-- удаляем временную таблицу
DROP TABLE CopyTable;

-- ПРОВЕРКА

--DELETE FROM ProductCharacteristics
--WHERE productCode = 11 AND characteristicCode = 1;

--INSERT INTO ProductCharacteristics
--VALUES (11, 1, 5);

---- проверка получившегося типа
--SELECT pc.*,
--       dt.name [Ожидаемый тип],
--       SQL_VARIANT_PROPERTY(pc.characteristicValue, 'basetype') [Действит тип]
--FROM ProductCharacteristics pc
--  JOIN Characteristics c ON pc.characteristicCode = c.code
--  JOIN DataTypes dt ON c.dataTypeCode = dt.code
--WHERE pc.characteristicCode = 1 AND pc.productCode = 11;