using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_Data_Layer
{
    public static class clsData_Client
    {

        /// <summary>
        /// search in the data base for client by Id and return variables by ref 
        /// </summary>
        /// <param name="Client_ID"></param>
        /// <returns> true if client found </returns> false if client not found
        public static bool Find_Client_By_ID
    (int Client_ID, ref int Person_ID, ref string AccountNumber, ref string PinCode, ref double Balance
    , ref string firstname, ref string lastname, ref string email,
    ref string phone, ref string country, ref string city, ref string street)
        {
            bool IsFound = false;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                string query = "SP_GetClientByID";

                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Client_ID", Client_ID);

                    try
                    {
                        connection.Open();

                        // Added using for SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Person_ID = (int)reader["Person_ID"];
                                AccountNumber = (string)reader["AccountNumber"];
                                PinCode = (string)reader["PinCode"];
                                Balance = Convert.ToDouble(reader["Balance"]);
                                firstname = (string)reader["FirstName"];
                                lastname = (string)reader["LastName"];
                                email = (string)reader["Email"];
                                phone = (string)reader["Phone"];
                                country = (string)reader["Country"];
                                city = (string)reader["City"];
                                street = (string)reader["Street"];
                            }
                        } // SqlDataReader disposed here
                    }
                    catch (Exception ex)
                    {
                        //Console.WriteLine("Error : " +  ex.Message);
                        IsFound = false;
                    }
                   
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here

            return IsFound;
        }


        /// <summary>
        /// Search in the data base for client by account number and edit variables by ref
        /// </summary>
        /// <param name="AccountNumber"></param>
        /// <returns> true if client found </returns> false if client not found
        public static bool Find_Client_By_AccountNumber
    (ref int Client_ID, ref int Person_ID, string AccountNumber, ref string PinCode, ref double Balance
    , ref string firstname, ref string lastname, ref string email,
    ref string phone, ref string country, ref string city, ref string street)
        {

            bool IsFound = false;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                string query = "SP_GetClientByAccountNumber";

                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                        command.CommandType = CommandType.StoredProcedure;

                    try
                    {
                        connection.Open();

                        // Added using for SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                IsFound = true;

                                Client_ID = (int)reader["Client_ID"];
                                Person_ID = (int)reader["Person_ID"];
                                PinCode = (string)reader["PinCode"];
                                Balance = Convert.ToDouble(reader["Balance"]);
                                firstname = (string)reader["FirstName"];
                                lastname = (string)reader["LastName"];
                                email = (string)reader["Email"];
                                phone = (string)reader["Phone"];
                                country = (string)reader["Country"];
                                city = (string)reader["City"];
                                street = (string)reader["Street"];
                            }
                            else
                                IsFound = false;
                        } // SqlDataReader disposed here
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                        IsFound = false;
                    }                
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here


            return IsFound;
        }


        /// <summary>
        /// Adding new Client to Data Base and geting the person ID and the Client ID also creating an accountnumber
        /// </summary>
        /// <returns> true if added successfully, false if not added  </returns>
        public static bool Add_New_Client(
     string PinCode, double Balance,
     string firstname, string lastname, string email,
     string phone, string country, string city, string street,
     ref int New_Person_ID, ref int New_Client_ID, ref string AccountNumber)
        {
            bool isSuccess = false;

            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_AddNewClient", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Input parameters
                command.Parameters.AddWithValue("@FirstName", firstname);
                command.Parameters.AddWithValue("@LastName", lastname);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Phone", phone);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@City", city);
                command.Parameters.AddWithValue("@Street", street);
                command.Parameters.AddWithValue("@PinCode", PinCode);
                command.Parameters.AddWithValue("@Balance", Balance);

                // Output parameters
                var pPersonID = new SqlParameter("@NewPersonID", SqlDbType.Int) { Direction = ParameterDirection.Output };
                var pAccountNumber = new SqlParameter("@AccountNumber", SqlDbType.NVarChar, 50) { Direction = ParameterDirection.Output };
                var pClientID = new SqlParameter("@NewClientID", SqlDbType.Int) { Direction = ParameterDirection.Output };

                command.Parameters.Add(pPersonID);
                command.Parameters.Add(pAccountNumber);
                command.Parameters.Add(pClientID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    // Assign returned values
                    if (pPersonID.Value != DBNull.Value)
                    {
                        New_Person_ID = (int)pPersonID.Value;
                        AccountNumber = pAccountNumber.Value?.ToString();
                        New_Client_ID = (int)pClientID.Value;
                        isSuccess = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isSuccess = false;
                }
            }

            return isSuccess;
        }

        public static bool Update_Client(int Client_ID, string PinCode, double Balance
    , string firstname, string lastname, string email,
    string phone, string country, string city, string street)
        {
            bool IsUpdated = false;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                // we have to update each person info and client info seperately becuase they are 2 different tables

                string query = @"SP_UpdateClient";


                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Added CommandType
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", firstname);
                    command.Parameters.AddWithValue("@LastName", lastname);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Country", country);
                    command.Parameters.AddWithValue("@City", city);
                    command.Parameters.AddWithValue("@street", street);

                    command.Parameters.AddWithValue("@PinCode", PinCode);
                    command.Parameters.AddWithValue("@Balance", Balance);
                    command.Parameters.AddWithValue("@Client_ID", Client_ID);

                    try
                    {
                        connection.Open();

                        int RowsEffected = command.ExecuteNonQuery();

                        if (RowsEffected > 0)
                            IsUpdated = true;
                        else
                            IsUpdated = false;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here


            return IsUpdated;
        }


        public static bool Delete_Client_By_ID(int Client_ID)
        {
            int RowsAffected = 0;
            string query = "SP_DeleteClientByID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Client_ID", Client_ID);

                    connection.Open();
                    RowsAffected = command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return RowsAffected > 0;
        }


        public static bool Is_Client_Exist(int Client_ID)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select found=1 from Clients where Client_ID = @Client_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Client_ID", Client_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static DataTable Get_All_Clients()
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
                {
                    string query = "SP_GetAllClients";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                            command.CommandType = CommandType.StoredProcedure;
                       
                            connection.Open();

                            using (SqlDataReader read = command.ExecuteReader())
                            {
                                if (read.HasRows)
                                {
                                    dt.Load(read);
                                }
                            } //sql Datareader is closed and disposed 

                    }// Sqlcommand is disposed here

                }// connection is closed and disposed here
            }
            catch (Exception )
            {
                 return null;
            }

                        return dt;

        }
    }
}
