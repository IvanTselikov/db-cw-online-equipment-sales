# db-cw-online-equipment-sales
**Приложение**: Windows Forms .Net Core

**СУБД**: MS SQL Server + SQL Server Management Studio

**Пакеты для установки (NuGet)**: Microsoft.Data.SqlClient

Для инициализации БД и её заполнения объектами необходимо:
* перейти в папку *db*;
* запустить *cmd*;
* выполнить команду `fill.bat server_name`, где `server_name` - имя вашего сервера MS SQL.
При этом выполнится восстановление БД из резервной копии *db/OnlineEquipmentSales.bak*, а также создание объектов БД с помощью сценариев в *db/object/\*.sql*

**ВАЖНО:** При добавлении новых .sql-файлов в *db/objects* следите за тем, чтобы сценарий выполнялся корректно целиком:
* замените ALTER TRIGGER/PROC на CREATE TRIGGER/PROC;
* используйте GO.
