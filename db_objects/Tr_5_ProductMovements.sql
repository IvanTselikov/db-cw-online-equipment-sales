CREATE TRIGGER movementProdCountControl ON ProductMovements
AFTER INSERT, UPDATE, DELETE
AS
	DECLARE @countProdPerWarehouse INT, @prodCode INT, @whNumber SMALLINT, @trDate DATETIME;

	SELECT @prodCode = productCode, @whNumber = warehouseNumber, @trDate = movementDate
	FROM INSERTED 
	
	SELECT @countProdPerWarehouse = SUM(productCount)
	FROM ProductMovements 
	WHERE productCode = @prodCode AND warehouseNumber = @whNumber AND movementDate <= @trDate

	IF @countProdPerWarehouse<0
	BEGIN
		RAISERROR('Движение не может быть создано. Не хватает товара на складе', 16, 1)
		ROLLBACK TRAN
	END