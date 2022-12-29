USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_CheckCharacteristicTypeCompliance 
ON ProductCharacteristics
AFTER INSERT, UPDATE
AS
  DECLARE @typeCode SMALLINT,
          @characteristicCode SMALLINT,
          @productCode INT;

  -- находим тип товара, характеристику дл€ которого добавил пользователь
  SELECT @typeCode = productTypeCode
  FROM inserted i JOIN Products p
    ON i.productCode = p.code;

  -- извлекаем характеристику, которую добавил пользователь
  SELECT @characteristicCode = characteristicCode
  FROM inserted;

  WHILE @typeCode IS NOT NULL
  BEGIN
    -- если добавл€ема€ характеристика соответствует типу товара или одному
    -- из "предков" типа товара, операци€ была корректна
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

  -- добавл€ема€ характеристика не соответствует ни типу товара, ни "предкам" типа
  RAISERROR('Ќевозможно добавить/изменить характеристику дл€ товара, т.к. она не соответствует типу данного товара.', 16, 10);
  ROLLBACK TRAN;
GO

-- ѕ–ќ¬≈– ј
--SELECT pt.name [тип]
--FROM Products p JOIN ProductTypes pt ON p.productTypeCode = pt.code
--WHERE p.code = 11;

--SELECT name [хар]
--FROM Characteristics
--WHERE code = 15;

--INSERT INTO ProductCharacteristics
--VALUES (11, 15, 4);
