if "%1"=="" (
    sqlcmd -E -S LAPTOP-J4FHUBL5\SQLEXPRESS -Q "RESTORE DATABASE OnlineEquipmentSales FROM DISK='OnlineEquipmentSales.bak'"
    cd objects
    for %%G in (*.sql) do sqlcmd /S LAPTOP-J4FHUBL5\SQLEXPRESS /d OnlineEquipmentSales -E -i"%%G"
) else (
    sqlcmd -E -S %1 -Q "RESTORE DATABASE OnlineEquipmentSales FROM DISK='OnlineEquipmentSales.bak'"
    cd objects
    for %%G in (*.sql) do sqlcmd /S %1 /d OnlineEquipmentSales -E -i"%%G"
)
pause
