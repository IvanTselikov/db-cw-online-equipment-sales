-- !!! �������� ������� Employees.dateOfDismissal (date, NULL) !!!
CREATE PROC sp_GetAvgWorkExperience
  @postCode TINYINT,
  @unit TINYINT = 0, -- 0 - � ����, 1 - ������, 2 - ����
  @avgExperience INT OUTPUT
AS
  SELECT @avgExperience = CASE @unit
    WHEN 0 THEN AVG(DATEDIFF(d, dateOfEmployment, COALESCE(dateOfDismissal, GETDATE())))
    WHEN 1 THEN AVG(DATEDIFF(m, dateOfEmployment, COALESCE(dateOfDismissal, GETDATE())))
    WHEN 2 THEN AVG(DATEDIFF(y, dateOfEmployment, COALESCE(dateOfDismissal, GETDATE()))) END
  FROM Employees
  WHERE postCode = @postCode;

CREATE INDEX IX_Employees_postCode
ON Employees (postCode)
INCLUDE (dateOfEmployment, dateOfDismissal);