USE OnlineEquipmentSales;
GO

-- ������ ������� ��� ������������� ������������ ��
-- � ������� ��������-��������
CREATE TABLE CustomersRegister(
  username SYSNAME NOT NULL,
  customerId INT NOT NULL,
  CONSTRAINT PK_CustomersRegister PRIMARY KEY (username, customerId),
  CONSTRAINT FK_CustomersRegister_customerId FOREIGN KEY (customerId)
    REFERENCES Customers(id)
);
GO

INSERT INTO CustomersRegister
VALUES ('Customer', 4);
GO

-- ������ �� ��� ������� � �������� �������� � ������������� ����������
-- �� ������
CREATE PROC sp_GetCustomerId
  @username SYSNAME,
  @customerId INT OUTPUT
AS
  SELECT @customerId = customerId
  FROM CustomersRegister;
GO

GRANT EXECUTE ON sp_GetCustomerId TO Customer;
GO

-- ������������� � ���������� ������� (����� - ���������� - ������)
CREATE VIEW OrderProducts
AS
  SELECT o.number [����� ������],
         p.[name] [�������� ������],
         pt.[name] [��� ������],
         -pm.productCount [����������, ��.],
         CASE WHEN o.discountPrc <= p.maxDiscountPercentage THEN o.discountPrc
           ELSE p.maxDiscountPercentage END [������, %]
  FROM ProductMovements pm JOIN Products p ON pm.productCode = p.code
    JOIN ProductTypes pt ON p.productTypeCode = pt.code
    JOIN Orders o ON pm.orderNumber = o.number
  WHERE productCount < 0;
GO

-- �� ��� ������� � �������������
CREATE PROC sp_GetOrderProducts
  @orderNumber INT = NULL
AS
  SELECT [�������� ������], [��� ������], [����������, ��.], [������, %]
  FROM OrderProducts
  WHERE [����� ������] = @orderNumber;
GO

GRANT EXECUTE ON sp_GetOrderProducts TO Customer;
GO