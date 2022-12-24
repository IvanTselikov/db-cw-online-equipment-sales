using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // NuGet Microsoft.Data.SqlClient
using System.Data;

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

        public SqlDataReader GetCustomerOrders()
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                int customerId = GetCustomerId();
                string spName = "sp_CustomerOrders",
                       param = "@customerId";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter customerIdParam = new SqlParameter
                {
                    ParameterName = param,
                    Value = customerId
                };
                command.Parameters.Add(customerIdParam);
                return command.ExecuteReader();
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        private int GetCustomerId()
        {
            string spName = "sp_GetCustomerId",
                       usernameString = "@username",
                       customerIdString = "@customerId";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter usernameParam = new SqlParameter
            {
                ParameterName = usernameString,
                Value = login
            };
            SqlParameter customerIdParam = new SqlParameter
            {
                ParameterName = customerIdString,
                SqlDbType = SqlDbType.Int
            };
            customerIdParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(usernameParam);
            command.Parameters.Add(customerIdParam);

            command.ExecuteNonQuery();

            return (int)command.Parameters[customerIdString].Value;
        }
    }
}
