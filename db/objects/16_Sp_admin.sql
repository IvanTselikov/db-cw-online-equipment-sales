USE OnlineEquipmentSales;
GO

-- ����������

-- ���������� �������, �������� ���� ���������/���������/����������/����� �����������:
CREATE TABLE EmployeeAssignments(
  id INT PRIMARY KEY IDENTITY,
  employeeId SMALLINT NOT NULL,
  prevPostCode TINYINT NULL, -- null, ���� ���������� ������ ������
  newPostCode TINYINT NULL, -- null, ���� ���������� �������
  assignmentDate DATETIME NOT NULL
);

-- ����� ����� ����������� NOT NULL �� ������� postCode ������� Employees,
-- �����������, ��� �������� NULL ����� ��������, ��� ��������� ������
ALTER TABLE Employees ALTER COLUMN postCode TINYINT NULL;
GO

-- ��������� ������� ��� ���������� ������� EmployeeAssignments � ������
-- ��������� ��������� ����������:
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

-- ��� ��

CREATE PROC sp_GetRequiredExperience
  @postCode TINYINT,
  @interval TINYINT = 1, -- 0 - � ����, 1 - � �������, 2 - � �����
  @avgExperience FLOAT OUTPUT
AS
  IF @interval NOT IN (0, 1, 2)
  BEGIN
    RAISERROR('��������� �������� �� ������������!', 16, 10);
    RETURN;
  END;

  WITH a AS -- �������� ������ ���������� ����������� �� ��������� ���������
    (SELECT employeeId, MIN(assignmentDate) assignmentDate
     FROM EmployeeAssignments
     WHERE newPostCode = @postCode
     GROUP BY employeeId),
       b AS -- ���������� ���� ����� ����������
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

-- �������
CREATE INDEX IX_EmployeeAssignments_newPostCode
ON EmployeeAssignments (newPostCode, employeeId)
INCLUDE (assignmentDate);

-- ��������

-- �������� ������� EmployeeAssignments ���������� �������
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
