USE OnlineEquipmentSales
GO

-- ����������

-- �������� � ������� deliveryDate ������� Orders ����� ���� null,
-- �.�. �������� �� ��������� ��� ��� �������������� �������� ��� ������������ ��������
-- � ������������ � ������-���������; ������� ������� ����������� NOT NULL:
ALTER TABLE Orders
ALTER COLUMN deliveryDate DATETIME NULL;

-- �������� � ������� employeeId ������� Orders ����� ���� null,
-- �.�. ����� ����� ����������� ��������, � ��������� �� ���� ��������� �������������;
-- ������� ������� ����������� NOT NULL:
ALTER TABLE Orders
ALTER COLUMN employeeId SMALLINT NULL;

-- ��� ������� ������ � ������� Orders ����� ����� ���������
-- ������� ���� (getdate()) � �������� �������� �� ���������;
ALTER TABLE Orders
ADD CONSTRAINT DF_Orders_orderDate
DEFAULT GETDATE() FOR orderDate;

-- ��� ��������  ������ ������ ����� ����� ��������� 0 � ��������
-- �������� �� ��������� ��� ���� sum, �.�. ����� �����������
-- ��� ������������ �������� �� ���������� ������� � ������� ProductMovements;
-- � ����� ������ ������������ ����������� ����������� sum > 0
-- ����� �������� �� sum >= 0:
ALTER TABLE Orders
DROP CONSTRAINT CK_Orders;

ALTER TABLE Orders
ADD CONSTRAINT CK_Orders
CHECK ([sum] >= 0);

CREATE TYPE ProductCount
AS TABLE(productCode INT, productCount INT);
GO

-- ���������

CREATE PROC sp_CreateOrder
  @customerId INT,
  @pickupPointNumber SMALLINT,
  @paymentMethodCode TINYINT,
  @products AS ProductCount READONLY,
  @deliveryDate DATETIME = NULL,
  @employeeId SMALLINT = NULL
AS
  SET NOCOUNT ON;

  -- �������� ����������
  IF @customerId NOT IN (SELECT id FROM Customers)
    RAISERROR('���������� ������� �� ����������!', 16, 10);
  ELSE IF @pickupPointNumber NOT IN (SELECT number FROM PickupPoints)
    RAISERROR('���������� ������ ������ �� ����������!', 16, 10);
  ELSE IF @paymentMethodCode NOT IN (SELECT code FROM PaymentMethods)
    RAISERROR('���������� ������� ������ �� ����������!', 16, 10);
  ELSE IF NOT EXISTS (SELECT * FROM @products)
    RAISERROR('������� ������ ��� �������!', 16, 10);
  ELSE
  BEGIN
    -- ��������� ������� ��� �������� ������� �� �������,
    -- ����� ��������� � �������� ������� � ������ ���������
    -- �������� ������
    DECLARE @movements TABLE(warehouseNumber SMALLINT,
                             productCode INT,
                             productCount INT,
                             supplierCode SMALLINT,
                             orderNumber INT,
                             movementDate DATETIME);
    DECLARE @productCode INT,
            @productCount INT,
            @orderDate DATETIME = GETDATE(),
            @error BIT = 0;

    -- ���������� ������ �� ��������� �������
    DECLARE crsr CURSOR FOR
    SELECT productCode, SUM(productCount) productCount
    FROM @products
    GROUP BY productCode;

    OPEN crsr;

    FETCH NEXT FROM crsr INTO @productCode, @productCount;

    WHILE @@FETCH_STATUS = 0
      BEGIN
        DECLARE @warehouseNumber SMALLINT, @deliveryTime SMALLINT;

        -- ���������� ������ �� ��������� �������
        -- (��, �� ������� ���� �������� � ��������� ����� ������),
        -- � ������ ������� - ����� ������� ������
        DECLARE crsr1 CURSOR FOR
        SELECT warehouseNumber, deliveryTime
        FROM Deliveries
        WHERE pickupPointNumber = @pickupPointNumber
        ORDER BY deliveryTime;

        OPEN crsr1;

        FETCH NEXT FROM crsr1 INTO @warehouseNumber, @deliveryTime;

        WHILE @@FETCH_STATUS = 0
          BEGIN
            -- ������� ���������� ������� ������ �� ������ ������
            DECLARE @pcWarehouse INT;

            SELECT @pcWarehouse = SUM(productCount)
            FROM ProductMovements
            WHERE productCode = @productCode AND warehouseNumber = @warehouseNumber;

            IF @pcWarehouse > 0
              BEGIN
                -- �������� �� ������ ������ (��� ����������� ���������)
                -- ���������� ������
                DECLARE @pcMovement INT = CASE WHEN @pcWarehouse > @productCount
                  THEN @productCount ELSE @pcWarehouse END;

                INSERT INTO @movements
                VALUES (@warehouseNumber,
                        @productCode,
                        @pcMovement * -1,
                        NULL,
                        NULL,
                        @orderDate);

                SET @productCount = @productCount - @pcMovement;
              END;

            IF @productCount = 0
              BREAK;

            FETCH NEXT FROM crsr1 INTO @warehouseNumber, @deliveryTime;
          END;

        CLOSE crsr1;
        DEALLOCATE crsr1;

        IF @productCount > 0 -- �� ������� ������������ �������
          BEGIN
            DECLARE @productName NVARCHAR(300);
            SELECT @productName = [name] FROM Products p WHERE p.code = @productCode;
            DECLARE @mes NVARCHAR(350) = '�� ������� �� ������� ������ ' + @productName + '!';
            RAISERROR(@mes, 16, 10);
            SET @error = 1;
          END;

        FETCH NEXT FROM crsr INTO @productCode, @productCount;
      END;

    CLOSE crsr;
    DEALLOCATE crsr;

    IF @error = 0 -- ������� ������� �������
      BEGIN
        -- ������ �����
        INSERT INTO Orders
        VALUES(0, @orderDate, NULL, @employeeId, @pickupPointNumber,
                8, @paymentMethodCode, @customerId, 0);

        -- �������� ����� ���������� ������
        DECLARE @orderNumber INT;
        SELECT TOP(1) @orderNumber = number
        FROM Orders
        ORDER BY number DESC;

        -- ��������� ����� ������ � ���������
        UPDATE @movements
        SET orderNumber = @orderNumber;

        -- ��������� �������� � ��
        INSERT INTO ProductMovements
        SELECT * FROM @movements;
      END;

    RETURN @error; -- 0 - �������� ����������, ����� - 1
  END;
  RETURN 1;
GO

CREATE INDEX IX_Deliveries_pickupPointNumber
ON Deliveries (pickupPointNumber, deliveryTime);

CREATE INDEX IX_ProductMovements_warehouseNumber_productCode
ON ProductMovements (warehouseNumber, productCode);

-- ��������

--DECLARE @products AS ProductCount; -- ��������� ���������� ��� �������� �������,
--                                   -- ������� ����� ������ � ������ ������
--INSERT INTO @products
--SELECT 2, 3
----UNION ALL
----SELECT 9, 1
----UNION ALL
----SELECT 1, 1;

--EXEC sp_CreateOrder 4, 4, 1, @products -- ����� �� ��� ���������� ������
