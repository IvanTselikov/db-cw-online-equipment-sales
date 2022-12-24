USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_ProductTypeChildControl
ON ProductTypeCharacteristics
INSTEAD OF INSERT, UPDATE
AS
	DECLARE @prTypeCode INT, @parentPrTypeCode INT, @charCode INT;
	SELECT @prTypeCode = productTypeCode, @charCode = characteristicCode
	FROM inserted

	SELECT @parentPrTypeCode = parentTypeCode
	FROM ProductTypes
	WHERE code=@prTypeCode
	
	WHILE @parentPrTypeCode IS NOT NULL
		BEGIN
			
			IF EXISTS (SELECT characteristicCode 
					   FROM ProductTypeCharacteristics 
					   WHERE characteristicCode = @charCode AND productTypeCode = @parentPrTypeCode)
				BEGIN
					RAISERROR('Характеристика дублирует характеристику родительского типа товара', 16, 1)
					RETURN
				END

			SELECT @parentPrTypeCode = parentTypeCode
			FROM ProductTypes
			WHERE code = @parentPrTypeCode;
		END
	INSERT INTO ProductTypeCharacteristics
	VALUES(@prTypeCode, @charCode)
