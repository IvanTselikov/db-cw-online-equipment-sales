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

        public SqlDataReader GetCustomerOrders(DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            if (sqlConnection != null && sqlConnection.State == System.Data.ConnectionState.Open)
            {
                int customerId = GetCustomerId();
                string spName = "sp_CustomerOrders",
                       param1 = "@customerId",
                       param2 = "@dateStart",
                       param3 = "@dateEnd";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection);
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter customerIdParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = customerId
                };
                command.Parameters.Add(customerIdParam);

                if (dateStart != null)
                {
                    SqlParameter dateStartParam = new SqlParameter
                    {
                        ParameterName = param2,
                        Value = dateStart
                    };
                    command.Parameters.Add(dateStartParam);
                }
                if (dateEnd != null)
                {
                    SqlParameter dateEndParam = new SqlParameter
                    {
                        ParameterName = param3,
                        Value = dateEnd
                    };
                    command.Parameters.Add(dateEndParam);
                }

                SqlDataReader reader = command.ExecuteReader();
                return reader;
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
