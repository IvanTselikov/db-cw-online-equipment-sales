USE OnlineEquipmentSales;
GO

CREATE PROC sp_GetDiscountStats
  @dateStart DATETIME = NULL,
  @dateEnd DATETIME = NULL,
  @mostPopularDiscount TINYINT OUTPUT,
  @mostUnpopularDiscount TINYINT OUTPUT
AS
  IF @dateStart IS NULL
    SET @dateStart = (SELECT MIN(orderDate) FROM Orders);
  IF @dateEnd IS NULL
    SET @dateEnd = GETDATE();
  IF @dateStart = @dateEnd -- скидки только в указанный день
    SET @dateEnd = DATEADD(dd, 1, @dateEnd);
  IF @dateEnd < @dateStart
  BEGIN
    RAISERROR('Дата конца рассматриваемого интервала не может быть меньше даты начала!', 16, 10);
    RETURN;
  END;
  WITH dscntStats AS
    (SELECT discountPrc, COUNT(number) popularity
     FROM Orders
     GROUP BY discountPrc),
    popular AS
    (SELECT TOP(1) discountPrc
     FROM dscntStats
     ORDER BY popularity DESC),
    unpopular AS
    (SELECT TOP(1) discountPrc
     FROM dscntStats
     ORDER BY popularity ASC)
  SELECT @mostPopularDiscount = p.discountPrc,
         @mostUnpopularDiscount = up.discountPrc
  FROM popular p, unpopular up;
GO

CREATE INDEX IX_Orders_discountPrc
ON Orders (discountPrc)
INCLUDE (number);
