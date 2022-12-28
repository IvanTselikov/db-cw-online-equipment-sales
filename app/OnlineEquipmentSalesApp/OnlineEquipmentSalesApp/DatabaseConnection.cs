using System;
using System.Data.SqlClient; // NuGet Microsoft.Data.SqlClient
using System.Data;
using System.Collections.Generic;

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
                catch (SqlException) { }
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

        public SqlDataReader GetCustomerOrders(DateTime? dateStart = null, DateTime? dateEnd = null)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_CustomerOrders",
                       param1 = "@customerId",
                       param2 = "@dateStart",
                       param3 = "@dateEnd";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter customerIdParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = GetCustomerId(),
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter dateStartParam = new SqlParameter
                {
                    ParameterName = param2,
                    Value = dateStart,
                    SqlDbType = SqlDbType.DateTime
                };
                SqlParameter dateEndParam = new SqlParameter
                {
                    ParameterName = param3,
                    Value = dateEnd,
                    SqlDbType = SqlDbType.DateTime
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(dateStartParam);
                command.Parameters.Add(dateEndParam);

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
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetCustomerId",
                       param1 = "@username",
                       param2 = "@customerId";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter usernameParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = login,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 128
                };
                SqlParameter customerIdParam = new SqlParameter
                {
                    ParameterName = param2,
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(usernameParam);
                command.Parameters.Add(customerIdParam);

                command.ExecuteNonQuery();

                return (int)command.Parameters[param2].Value;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetOrderProducts(int? orderNumber = null)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetOrderProducts",
                       param1 = "@orderNumber";
                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter orderNumberParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = orderNumber,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(orderNumberParam);

                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public void CancelOrder(int orderNumber)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_CancelOrder",
                       param1 = "@orderNumber";
                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter orderNumberParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = orderNumber,
                    SqlDbType = SqlDbType.Int
                };
                command.Parameters.Add(orderNumberParam);
                command.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetProductTypes()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetProductTypes";
                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetProductsOfType(short? typeCode = null)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetProductsOfType",
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
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetPickupPointsAddresses()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetPickupPointsAddresses";
                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetPaymentMethods()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetPaymentMethods";
                SqlCommand command = new SqlCommand(spName, this.sqlConnection) 
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public int GetPickupPointProductCount(int productCode, int? pickupPointNumber = null)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetPickupPointProductCount",
                       param1 = "@productCode ",
                       param2 = "@pickupPointNumber",
                       param3 = "@productCount";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter productCodeParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = productCode,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter pickupPointNumberParam = new SqlParameter
                {
                    ParameterName = param2,
                    Value = pickupPointNumber,
                    SqlDbType = SqlDbType.SmallInt
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
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public short GetDefaultProductType()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetDefaultProductType",
                       param1 = "@productTypeCode";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter productTypeCodeParam = new SqlParameter
                {
                    ParameterName = param1,
                    SqlDbType = SqlDbType.SmallInt,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(productTypeCodeParam);

                command.ExecuteNonQuery();
                return (short)command.Parameters[param1].Value;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public string GetTypeOfProduct(int productCode)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
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
                    Value = productCode,
                    SqlDbType = SqlDbType.Int
                };

                SqlParameter typeNameParam = new SqlParameter
                {
                    ParameterName = param2,
                    SqlDbType = SqlDbType.NVarChar,
                    Size = 300,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(productCodeParam);
                command.Parameters.Add(typeNameParam);

                command.ExecuteNonQuery();
                return command.Parameters[param2].Value.ToString();
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetCharacteristicsOfType(short typeCode)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
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
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader FindProductsByCharacteristic(short typeCode,
                                                          short characteristicCode,
                                                          object characteristicValue)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
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
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }
    
        public byte GetCharacteristicDataType(short characteristicCode)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
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
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public SqlDataReader GetProductInfo(int productCode)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetProductInfo",
                       param1 = "@productCode";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter productCodeParam = new SqlParameter
                {
                    ParameterName = param1,
                    Value = productCode,
                    SqlDbType = SqlDbType.Int
                };

                command.Parameters.Add(productCodeParam);

                SqlDataReader reader = command.ExecuteReader();
                return reader;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public byte GetCustomerDiscount()
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetCustomerDiscount",
                       param1 = "@customerId",
                       param2 = "@discount";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter customerIdParam = new SqlParameter()
                {
                    ParameterName = param1,
                    Value = GetCustomerId(),
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter discountParam = new SqlParameter()
                {
                    ParameterName = param2,
                    SqlDbType = SqlDbType.TinyInt,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(discountParam);

                command.ExecuteNonQuery();
                return (byte)command.Parameters[param2].Value;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public void GetProductOrderInfo(int productCode, int productCount, byte orderDiscount,
                                        out decimal productPrice, out byte productDiscount)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_GetProductOrderInfo",
                       param1 = "@productCode",
                       param2 = "@productCount",
                       param3 = "@orderDiscount",
                       param4 = "@productPrice",
                       param5 = "@productDiscount";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter productCodeParam = new SqlParameter()
                {
                    ParameterName = param1,
                    Value = productCode,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter productCountParam = new SqlParameter()
                {
                    ParameterName = param2,
                    Value = productCount,
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter orderDiscountParam = new SqlParameter()
                {
                    ParameterName = param3,
                    Value = orderDiscount,
                    SqlDbType = SqlDbType.TinyInt
                };
                SqlParameter productPriceParam = new SqlParameter()
                {
                    ParameterName = param4,
                    SqlDbType = SqlDbType.Money,
                    Direction = ParameterDirection.Output
                };
                SqlParameter productDiscountParam = new SqlParameter()
                {
                    ParameterName = param5,
                    SqlDbType = SqlDbType.TinyInt,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(productCodeParam);
                command.Parameters.Add(productCountParam);
                command.Parameters.Add(orderDiscountParam);
                command.Parameters.Add(productPriceParam);
                command.Parameters.Add(productDiscountParam);

                command.ExecuteNonQuery();

                productPrice = (decimal)command.Parameters[param4].Value;
                productDiscount = (byte)command.Parameters[param5].Value;
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }

        public class Product
        {
            public int Code { get; set; }
            public int Count { get; set; }

            public Product(int code, int count)
            {
                Code = code;
                Count = count;
            }
        }

        public void CreateOrder(short pickupPointNumber,
                                byte paymentMethodCode,
                                List<Product> products,
                                DateTime? deliveryDate = null,
                                short? employeeId = null)
        {
            if (sqlConnection != null && sqlConnection.State == ConnectionState.Open)
            {
                string spName = "sp_CreateOrder",
                       param1 = "@customerId",
                       param2 = "@pickupPointNumber",
                       param3 = "@paymentMethodCode",
                       param4 = "@products",
                       param5 = "@deliveryDate",
                       param6 = "@employeeId";

                SqlCommand command = new SqlCommand(spName, this.sqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                SqlParameter customerIdParam = new SqlParameter()
                {
                    ParameterName = param1,
                    Value = GetCustomerId(),
                    SqlDbType = SqlDbType.Int
                };
                SqlParameter pickupPointNumberParam = new SqlParameter()
                {
                    ParameterName = param2,
                    Value = pickupPointNumber,
                    SqlDbType = SqlDbType.SmallInt
                };
                SqlParameter paymentMethodCodeParam = new SqlParameter()
                {
                    ParameterName = param3,
                    Value = paymentMethodCode,
                    SqlDbType = SqlDbType.TinyInt
                };

                DataTable productsTable = new DataTable();
                productsTable.Columns.Add("productCode");
                productsTable.Columns.Add("productCount");

                foreach (Product p in products)
                {
                    productsTable.Rows.Add(p.Code, p.Count);
                }

                SqlParameter productsParam = new SqlParameter()
                {
                    ParameterName = param4,
                    Value = productsTable,
                    SqlDbType = SqlDbType.Structured,
                    TypeName = "dbo.ProductCount"
                };
                SqlParameter deliveryDateParam = new SqlParameter()
                {
                    ParameterName = param5,
                    Value = deliveryDate,
                    SqlDbType = SqlDbType.DateTime
                };
                SqlParameter employeeIdParam = new SqlParameter()
                {
                    ParameterName = param6,
                    Value = employeeId,
                    SqlDbType = SqlDbType.SmallInt
                };

                command.Parameters.Add(customerIdParam);
                command.Parameters.Add(pickupPointNumberParam);
                command.Parameters.Add(paymentMethodCodeParam);
                command.Parameters.Add(productsParam);
                command.Parameters.Add(deliveryDateParam);
                command.Parameters.Add(employeeIdParam);

                command.ExecuteNonQuery();
            }
            else
            {
                throw new Exception("Соединение не установлено!");
            }
        }
    }
}
