using BAIS3150_WEBAPI_LAB5.Domain;
using Microsoft.Data.SqlClient;
using System.Data;


namespace BAIS3150_WEBAPI_LAB5.TechnicalServices
{
    public class customerOperation
    {
        private string connectionString;

        public customerOperation()
        {
            connectionString = $@"Persist Security Info=False; Integrated Security=False; User ID={Environment.GetEnvironmentVariable("BAIST_USERNAME", EnvironmentVariableTarget.User)}; Password={Environment.GetEnvironmentVariable("BAIST_PASSWORD", EnvironmentVariableTarget.User)}; Database=Northwind; server=dev1.baist.ca; TrustServerCertificate=True;";
        }

        public List<customers> GetCustomers()
        {
            try
            {
                if (!TestDatabaseConnection())
                {
                    throw new Exception("Database connection is not valid.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand GetCustomers = new SqlCommand("rgupta6.GetAllCustomers", connection);
                    GetCustomers.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = GetCustomers.ExecuteReader();
                    List<customers> customersList = new List<customers>();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            customers customer = new customers
                            {
                                CustomerID = reader["CustomerID"].ToString(),
                                CompanyName = reader["CompanyName"].ToString(),
                                ContactName = reader["ContactName"].ToString(),
                                ContactTitle = reader["ContactTitle"].ToString(),
                                Address = reader["Address"].ToString(),
                                City = reader["City"].ToString(),
                                Region = reader["Region"].ToString(),
                                PostalCode = reader["PostalCode"].ToString(),
                                Country = reader["Country"].ToString(),
                                Phone = reader["Phone"].ToString(),
                                Fax = reader["Fax"].ToString()
                            };
                            customersList.Add(customer);
                        }
                    }
                    else
                    {
                        throw new Exception("No customers found.");
                    }

                    reader.Close();

                    return customersList;
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the SQL exception (if logging is implemented)
                throw new Exception("A SQL error occurred while retrieving customers.", sqlEx);
            }
            catch (Exception ex)
            {
                // Log the general exception (if logging is implemented)
                throw new Exception("An error occurred while retrieving customers.", ex);
            }
        }

        public customers GetCustomerByID(string customerID)
        {
            try
            {
                if (!TestDatabaseConnection())
                {
                    throw new Exception("Database connection is not valid.");
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    SqlCommand GetCustomerByID = new SqlCommand("rgupta6.GetCustomerByID", connection);
                    GetCustomerByID.CommandType = CommandType.StoredProcedure;
                    GetCustomerByID.Parameters.AddWithValue("@CustomerID", customerID);

                    SqlDataReader reader = GetCustomerByID.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        customers customer = new customers
                        {
                            CustomerID = reader["CustomerID"].ToString(),
                            CompanyName = reader["CompanyName"].ToString(),
                            ContactName = reader["ContactName"].ToString(),
                            ContactTitle = reader["ContactTitle"].ToString(),
                            Address = reader["Address"].ToString(),
                            City = reader["City"].ToString(),
                            Region = reader["Region"].ToString(),
                            PostalCode = reader["PostalCode"].ToString(),
                            Country = reader["Country"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Fax = reader["Fax"].ToString()
                        };

                        reader.Close();
                        return customer;
                    }
                    else
                    {
                        throw new Exception("Customer not found.");
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                // Log the SQL exception (if logging is implemented)
                throw new Exception("A SQL error occurred while retrieving the customer.", sqlEx);
            }
            catch (Exception ex)
            {
                // Log the general exception (if logging is implemented)
                throw new Exception("An error occurred while retrieving the customer.", ex);
            }
        }

        private bool TestDatabaseConnection()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT 1", connection))
                    {
                        command.ExecuteScalar();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                // Log the exception (if logging is implemented)
                return false;
            }
        }
    }
}
