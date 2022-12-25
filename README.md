# db-cw-online-equipment-sales
**Приложение**: Windows Forms .Net Core

**СУБД**: MS SQL Server + SQL Server Management Studio

**Пакеты для установки (NuGet)**: Microsoft.Data.SqlClient

Для заполнения БД необходимо:
* открыть SQL Server Management Studio;
* восстановить БД из *db/OnlineEquipmentSales.bak*;
* запустить скрипт *db/fill.bat* для создания объектов БД.

**ВАЖНО:** При добавлении новых .sql-файлов в *db/objects* следите за тем, чтобы сценарий выполнялся корректно целиком:
* замените ALTER TRIGGER/PROC на CREATE TRIGGER/PROC;
* используйте GO.
