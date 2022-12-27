using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient; // NuGet Microsoft.Data.SqlClient
using System.Data;

namespace OnlineEquipmentSalesApp
{
    class DatabaseConnection
    {
        private string dbName = "OnlineEquipmentSales",
                       login = "Customer";

        private SqlConnection sqlConnection;

        public bool Login(string serverName, string password)
        {
            if (sqlConnection == null || sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                string connectionString =
                    $"Data Source={serverName};" +
                    $"Initial Catalog={this.dbName};" +
                    $"User Id={this.login};Password={password};" +
                    "Integrated Security=False;" +
                    "Connect Timeout=3";

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
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
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

        public SqlDataReader GetOrderProducts(int? orderNumber = null)
        {
            string spName = "sp_GetOrderProducts",
                       param1 = "@orderNumber";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter orderNumberParam = new SqlParameter
            {
                ParameterName = param1,
                Value = orderNumber
            };
            command.Parameters.Add(orderNumberParam);

            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public void CancelOrder(int orderNumber)
        {
            string spName = "sp_CancelOrder",
                   param1 = "@orderNumber";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter orderNumberParam = new SqlParameter
            {
                ParameterName = param1,
                Value = orderNumber
            };
            command.Parameters.Add(orderNumberParam);
            command.ExecuteNonQuery();
        }

        public SqlDataReader GetProductTypes()
        {
            string spName = "sp_GetProductTypes";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader GetProductsOfType(int? typeCode = null)
        {
            string spName = "sp_GetProductsOfType",
                   param1 = "@typeCode";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter typeNameParam = new SqlParameter
            {
                ParameterName = param1,
                Value = typeCode
            };
            command.Parameters.Add(typeNameParam);
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader GetPickupPointsAddresses()
        {
            string spName = "sp_GetPickupPointsAddresses";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader GetPaymentMethods()
        {
            string spName = "sp_GetPaymentMethods";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public int GetPickupPointProductCount(int productCode, int? pickupPointNumber = null)
        {
            string spName = "sp_GetPickupPointProductCount",
                   param1 = "@productCode ",
                   param2 = "@pickupPointNumber",
                   param3 = "@productCount";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter productCodeParam = new SqlParameter
            {
                ParameterName = param1,
                SqlDbType = SqlDbType.Int,
                Value = productCode
            };

            SqlParameter pickupPointNumberParam = new SqlParameter
            {
                ParameterName = param2,
                SqlDbType = SqlDbType.SmallInt,
                Value = pickupPointNumber
            };

            SqlParameter productCountParam = new SqlParameter
            {
                ParameterName = param3,
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(productCodeParam);
            command.Parameters.Add(pickupPointNumberParam);
            command.Parameters.Add(productCountParam);

            command.ExecuteNonQuery();
            return (int)command.Parameters[param3].Value;
        }

        public short GetDefaultProductType()
        {
            string spName = "sp_GetDefaultProductType",
                   param1 = "@productTypeCode";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection);
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter productTypeCodeParam = new SqlParameter
            {
                ParameterName = param1,
                SqlDbType = SqlDbType.SmallInt
            };
            productTypeCodeParam.Direction = ParameterDirection.Output;
            command.Parameters.Add(productTypeCodeParam);

            command.ExecuteNonQuery();
            return (short)command.Parameters[param1].Value;
        }

        public string GetTypeOfProduct(int productCode)
        {
            string spName = "sp_GetTypeOfProduct",
                   param1 = "@productCode",
                   param2 = "@typeName";

            SqlCommand command = new SqlCommand(spName, this.sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter productCodeParam = new SqlParameter
            {
                ParameterName = param1,
                SqlDbType = SqlDbType.Int,
                Value = productCode
            };

            SqlParameter typeNameParam = new SqlParameter
            {
                ParameterName = param2,
                SqlDbType = SqlDbType.NVarChar,
                Size = 300,
                Direction = ParameterDirection.Output
            };

            command.ExecuteNonQuery();
            return command.Parameters[param2].Value.ToString();
        }

        public SqlDataReader GetCharacteristicsOfType(short typeCode)
        {
            string spName = "sp_GetCharacteristicsOfType",
                   param1 = "@typeCode";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };
            SqlParameter typeCodeParam = new SqlParameter
            {
                ParameterName = param1,
                Value = typeCode,
                SqlDbType = SqlDbType.SmallInt
            };
            command.Parameters.Add(typeCodeParam);

            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }

        public SqlDataReader FindProductsByCharacteristic(short typeCode,
                                                          short characteristicCode,
                                                          object characteristicValue)
        {
            string spName = "sp_FindProductByCharacteristic",
                   param1 = "@typeCode",
                   param2 = "@characteristic",
                   param3 = "@value";
            SqlCommand command = new SqlCommand(spName, this.sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter typeCodeParam = new SqlParameter
            {
                ParameterName = param1,
                Value = typeCode,
                SqlDbType = SqlDbType.SmallInt
            };
            SqlParameter characteristicCodeParam = new SqlParameter
            {
                ParameterName = param2,
                Value = characteristicCode,
                SqlDbType = SqlDbType.SmallInt                
            };
            SqlParameter characteristicValueParam = new SqlParameter
            {
                ParameterName = param3,
                Value = characteristicValue,
                SqlDbType = SqlDbType.Variant
            };

            command.Parameters.Add(typeCodeParam);
            command.Parameters.Add(characteristicCodeParam);
            command.Parameters.Add(characteristicValueParam);

            SqlDataReader reader = command.ExecuteReader();
            return reader;
        }
    
        public byte GetCharacteristicDataType(short characteristicCode)
        {
            string spName = "sp_GetCharacteristicDataType",
                   param1 = "@characteristicCode",
                   param2 = "@dataTypeCode";

            SqlCommand command = new SqlCommand(spName, this.sqlConnection)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlParameter characteristicCodeParam = new SqlParameter
            {
                ParameterName = param1,
                Value = characteristicCode,
                SqlDbType = SqlDbType.SmallInt
            };

            SqlParameter dataTypeCodeParam = new SqlParameter
            {
                ParameterName = param2,
                SqlDbType = SqlDbType.TinyInt,
                Direction = ParameterDirection.Output
            };

            command.Parameters.Add(characteristicCodeParam);
            command.Parameters.Add(dataTypeCodeParam);

            command.ExecuteNonQuery();
            return (byte)command.Parameters[param2].Value;
        }
    }
}
