cd objects
for %%G in (*.sql) do sqlcmd /S LAPTOP-J4FHUBL5\SQLEXPRESS /d OnlineEquipmentSales -E -i"%%G"
pause