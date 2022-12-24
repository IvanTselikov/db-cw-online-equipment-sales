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
ALTER PROC sp_GetCustomerId
  @username SYSNAME,
  @customerId INT OUTPUT
AS
  SELECT @customerId = customerId
  FROM CustomersRegister;
GO

GRANT EXECUTE ON sp_GetCustomerId TO Customer;
GO
