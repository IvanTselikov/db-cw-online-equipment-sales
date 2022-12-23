using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // NuGet Microsoft.Data.SqlClient

namespace OnlineEquipmentSalesApp
{
    class DatabaseConnection
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=LAPTOP-J4FHUBL5\SQLEXPRESS;" +
                                                         "Initial Catalog:OnlineEquipmentSales;" +
                                                         "Integrated Security=True");


        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }

        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
    }
}
