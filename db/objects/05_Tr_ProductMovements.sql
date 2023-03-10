USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_MovementProdCountControl
ON ProductMovements
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
		RAISERROR('???????? ?? ????? ???? ???????. ?? ??????? ?????? ?? ??????', 16, 1)
		ROLLBACK TRAN
	END

-- ????????

--UPDATE ProductMovements
--SET productCount = -10000000;
