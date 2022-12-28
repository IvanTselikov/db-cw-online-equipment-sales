# db-cw-online-equipment-sales

**Платформа (приложение)**: Windows Forms .Net Core

**СУБД**: MS SQL Server + SQL Server Management Studio

**Пакеты для установки (NuGet)**: Microsoft.Data.SqlClient

Для инициализации БД и её заполнения объектами необходимо:
* перейти в папку *db*;
* запустить *cmd*;
* выполнить команду `fill.bat server_name`, где `server_name` - имя вашего сервера MS SQL.
При этом выполнится восстановление БД из резервной копии *db/OnlineEquipmentSales.bak*, а также создание объектов БД с помощью сценариев в *db/object/\*.sql*

Перед запуском приложения убедитесь, что на вашем сервере разрешена аутентификация по логинам SQL.
