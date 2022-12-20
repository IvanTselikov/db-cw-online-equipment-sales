CREATE PROC sp_GetDiscountStats
  @mostPopularDiscount TINYINT OUTPUT,
  @mostUnpopularDiscount TINYINT OUTPUT
AS
  WITH dscntStats AS
    (SELECT discountPercentage, COUNT(id) popularity
     FROM Customers
     GROUP BY discountPercentage),
    popular AS
    (SELECT TOP(1) discountPercentage
     FROM dscntStats
     ORDER BY popularity DESC),
    unpopular AS
    (SELECT TOP(1) discountPercentage
     FROM dscntStats
     ORDER BY popularity ASC)
  SELECT @mostPopularDiscount = p.discountPercentage,
         @mostUnpopularDiscount = up.discountPercentage
  FROM popular p, unpopular up;

CREATE INDEX IX_Customers_DiscountPercentage
ON Customers (discountPercentage)
INCLUDE (id);
