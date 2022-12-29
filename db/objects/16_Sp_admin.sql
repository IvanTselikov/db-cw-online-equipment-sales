USE OnlineEquipmentSales;
GO

-- ПОДГОТОВКА

-- необходима таблица, хранящая даты повышений/понижений/увольнений/найма сотрудников:
CREATE TABLE EmployeeAssignments(
  id INT PRIMARY KEY IDENTITY,
  employeeId SMALLINT NOT NULL,
  prevPostCode TINYINT NULL, -- null, если сотрудника только наняли
  newPostCode TINYINT NULL, -- null, если сотрудника уволили
  assignmentDate DATETIME NOT NULL
);

-- нужно снять ограничение NOT NULL со столбца postCode таблицы Employees,
-- предполагая, что значение NULL будет означать, что сотрудник уволен
ALTER TABLE Employees ALTER COLUMN postCode TINYINT NULL;
GO

-- необходим триггер для заполнения таблицы EmployeeAssignments в случае
-- изменения должности сотрудника:
CREATE TRIGGER tr_AddAssignment
ON Employees
AFTER INSERT, UPDATE
AS
  DECLARE @employeeId SMALLINT,
          @prevPostCode TINYINT,
          @newPostCode TINYINT,
          @assignmentDate DATETIME = GETDATE();

  SELECT @prevPostCode = postCode FROM deleted;
  SELECT @newPostCode = postCode, @employeeId = id FROM inserted;

  IF @prevPostCode <> @newPostCode
    INSERT INTO EmployeeAssignments
    VALUES(@employeeId, @prevPostCode, @newPostCode, @assignmentDate);
GO

-- КОД ХП

CREATE PROC sp_GetRequiredExperience
  @postCode TINYINT,
  @interval TINYINT = 1, -- 0 - в днях, 1 - в месяцах, 2 - в годах
  @avgExperience FLOAT OUTPUT
AS
  IF @interval NOT IN (0, 1, 2)
  BEGIN
    RAISERROR('Указанный интервал не предусмотрен!', 16, 10);
    RETURN;
  END;

  WITH a AS -- выбираем первые назначения сотрудников на указанную должность
    (SELECT employeeId, MIN(assignmentDate) assignmentDate
     FROM EmployeeAssignments
     WHERE newPostCode = @postCode
     GROUP BY employeeId),
       b AS -- дописываем дату найма сотрудника
    (SELECT a.employeeId, a.assignmentDate, ea.assignmentDate dateOfHiring
     FROM a JOIN EmployeeAssignments ea ON a.employeeId = ea.employeeId
     WHERE prevPostCode IS NULL)
  SELECT @avgExperience = AVG(
    CASE @interval
      WHEN 0 THEN DATEDIFF(dd, dateOfHiring, assignmentDate)
      WHEN 1 THEN DATEDIFF(mm, dateOfHiring, assignmentDate)
      WHEN 2 THEN DATEDIFF(yyyy, dateOfHiring, assignmentDate)
    END * 1.0)
  FROM b;
GO

-- ИНДЕКСЫ
CREATE INDEX IX_EmployeeAssignments_newPostCode
ON EmployeeAssignments (newPostCode, employeeId)
INCLUDE (assignmentDate);

-- ПРОВЕРКА

-- заполним таблицу EmployeeAssignments временными данными
--INSERT INTO EmployeeAssignments
--SELECT  1, 	NULL,	1,	CONVERT(DATETIME, '25.01.2022', 104)
--UNION ALL
--SELECT  2, 	NULL,	1,	CONVERT(DATETIME, '21.02.2021', 104)
--UNION ALL
--SELECT  2,	1,	2,	CONVERT(DATETIME, '23.08.2021', 104)
--UNION ALL
--SELECT  3,	NULL,	3,	CONVERT(DATETIME, '16.09.2022', 104)
--UNION ALL
--SELECT  3,	3,	1,	CONVERT(DATETIME, '22.12.2022', 104)
--UNION ALL
--SELECT  4,	NULL,	3,	CONVERT(DATETIME, '18.09.2021', 104)
--UNION ALL
--SELECT  5,	NULL,	3,	CONVERT(DATETIME, '01.01.2022', 104)
--UNION ALL
--SELECT  5,	3,	2,	CONVERT(DATETIME, '12.07.2022', 104)
--UNION ALL
--SELECT  6,	NULL,	3,	CONVERT(DATETIME, '31.01.2021', 104);

--DECLARE @postCode TINYINT = 2, @res FLOAT;
--EXEC sp_GetRequiredExperience @postCode = @postCode,
--                              @interval = 1,
--                              @avgExperience = @res OUTPUT;
--PRINT @res;
