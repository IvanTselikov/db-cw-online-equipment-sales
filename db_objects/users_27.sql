CREATE LOGIN Administrator WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Administrator FOR LOGIN Administrator;

GRANT EXECUTE ON sp_GetAvgOrderSum TO Administrator; -- №15
GRANT EXECUTE ON sp_GetRequiredExperience TO Administrator; -- №16
-- GRANT EXECUTE ON ... TO Administrator; -- №17
-- GRANT EXECUTE ON ... TO Administrator; -- №18
GRANT EXECUTE ON sp_GetDiscountStats TO Administrator; -- №19


CREATE LOGIN Manager WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Manager FOR LOGIN Manager;

GRANT EXECUTE ON sp_GetBoredCustomers TO Manager; -- №20
-- GRANT EXECUTE ON ... TO Manager; -- №21
-- GRANT EXECUTE ON ... TO Manager; -- №22


CREATE LOGIN Warehouseman WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Warehouseman FOR LOGIN Warehouseman;

GRANT EXECUTE ON sp_GetWarehouseAvgWorkload TO Warehouseman; -- №23
GRANT EXECUTE ON sp_GetUnclaimedProducts TO Warehouseman; -- №24


CREATE LOGIN Customer WITH PASSWORD = '12345', DEFAULT_DATABASE = OnlineEquipmentSales;
CREATE USER Customer FOR LOGIN Customer;

-- GRANT EXECUTE ON ... TO Warehouseman; -- №25
-- GRANT EXECUTE ON ... TO Warehouseman; -- №26


GRANT EXECUTE ON sp_CreateOrder TO Customer; -- ХП для добавления заказа
GRANT EXECUTE ON sp_CancelOrder TO Customer; -- ХП для отмены заказа
-- GRANT EXECUTE ON ... TO Customer; -- ХП для регистрации покупателя
-- GRANT EXECUTE ON ... TO Administrator; -- ХП для добавления нового товара
