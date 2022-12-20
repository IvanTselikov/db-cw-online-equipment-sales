CREATE TRIGGER Tr_ProductCharacteristics_2
ON ProductCharacteristics
AFTER INSERT, UPDATE
AS
  DECLARE @typeCode SMALLINT,
          @characteristicCode SMALLINT,
          @productCode INT;

  -- находим тип товара, характеристику для которого добавил пользователь
  SELECT @typeCode = productTypeCode
  FROM inserted i JOIN Products p
    ON i.productCode = p.code;

  -- извлекаем характеристику, которую добавил пользователь
  SELECT @characteristicCode = characteristicCode
  FROM inserted;

  WHILE @typeCode IS NOT NULL
  BEGIN
    -- если добавляемая характеристика соответствует типу товара или одному
    -- из "предков" типа товара, операция была корректна
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

  -- добавляемая характеристика не соответствует ни типу товара, ни "предкам" типа
  RAISERROR('Невозможно добавить/изменить характеристику для товара, т.к. она не соответствует типу данного товара.', 16, 10);
  ROLLBACK TRAN;