using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // NuGet Microsoft.Data.SqlClient

namespace OnlineEquipmentSalesApp
{
    class DatabaseConnection
    {
        private string serverName = @"LAPTOP-J4FHUBL5\SQLEXPRESS",
                       dbName = "OnlineEquipmentSales",
                       login = "Customer";

        private SqlConnection sqlConnection;

        public bool Login(string password)
        {
            if (sqlConnection == null || sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                string connectionString =
                    $"Data Source={this.serverName};" +
                    $"Initial Catalog={this.dbName};" +
                    $"User Id={this.login};Password={password};" +
                    "Integrated Security=False";

                this.sqlConnection = new SqlConnection(connectionString);

                try
                {
                    this.sqlConnection.Open();
                    return true;
                }
                catch (SqlException failedLoginException) { }
            }
            return false;
        }

        public void Logout()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return sqlConnection;
        }
    }
}
