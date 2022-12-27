USE OnlineEquipmentSales;
GO

-- �������� ������������� � ������ ����������
CREATE LOGIN Administrator WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Administrator FOR LOGIN Administrator;

GRANT EXECUTE ON sp_GetAvgOrderSum TO Administrator; -- �15
GRANT EXECUTE ON sp_GetRequiredExperience TO Administrator; -- �16
GRANT EXECUTE ON sp_GetSalesPerType TO Administrator; -- �17
GRANT EXECUTE ON sp_GetUnclaimedWarehouses TO Administrator; -- �18
GRANT EXECUTE ON sp_GetDiscountStats TO Administrator; -- �19


CREATE LOGIN Manager WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Manager FOR LOGIN Manager;

GRANT EXECUTE ON sp_GetBoredCustomers TO Manager; -- �20
GRANT EXECUTE ON sp_MaxRevenueMonth TO Manager; -- �21
GRANT EXECUTE ON sp_AvgSumOfCanceledOrders TO Manager; -- �22


CREATE LOGIN Warehouseman WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Warehouseman FOR LOGIN Warehouseman;

GRANT EXECUTE ON sp_GetWarehouseAvgWorkload TO Warehouseman; -- �23
GRANT EXECUTE ON sp_GetUnclaimedProducts TO Warehouseman; -- �24


CREATE LOGIN Customer WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Customer FOR LOGIN Customer;

GRANT EXECUTE ON sp_CustomerOrders TO Customer; -- �25
GRANT EXECUTE ON sp_FindProductByCharacteristic TO Customer; -- �26


GRANT EXECUTE ON sp_CreateOrder TO Customer; -- �� ��� ���������� ������
GRANT EXECUTE ON sp_CancelOrder TO Customer; -- �� ��� ������ ������
GRANT EXECUTE ON sp_AddCustomer TO Administrator; -- �� ��� ����������� ����������
GRANT EXECUTE ON sp_AddProduct TO Administrator; -- �� ��� ���������� ������ ������

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