USE OnlineEquipmentSales
GO

CREATE TRIGGER tr_CheckEmployeeBirthDate
ON Employees
AFTER INSERT, UPDATE
AS
  DECLARE @dob DATE;
  SELECT @dob = dateOfBirth
  FROM inserted;
  IF DATEDIFF(d, @dob, GETDATE()) <= 0
  BEGIN
    RAISERROR('Дата рождения сотрудника должна быть меньше текущей даты!', 16, 10);
  END;
