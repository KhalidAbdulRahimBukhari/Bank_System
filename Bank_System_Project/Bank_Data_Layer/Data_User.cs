using System;
using System.Data;
using System.Data.SqlClient;

namespace Bank_Data_Layer
{
    public class clsData_User
    {
        public static bool Find_By_User_ID(int User_ID, ref string Username, ref string Password, ref int Permissions, ref int Person_ID
        , ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Country
        , ref string City, ref string street)
        {
            bool IsFound = false;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                string query = "SP_GetUserByID";

                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Added CommandType
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@User_ID", User_ID);

                    try
                    {
                        connection.Open();

                        // Added using for SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                Username = (string)reader["UserName"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                Person_ID = (int)reader["Person_ID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Email = (string)reader["Email"];
                                Phone = (string)reader["Phone"];
                                Country = (string)reader["Country"];
                                City = (string)reader["City"];
                                street = (string)reader["street"];
                            }


                        } // SqlDataReader disposed here
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }                   
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here


            return IsFound;
        }



        public static bool Find_By_UserName(ref int User_ID, string Username, ref string Password, ref int Permissions, ref int Person_ID
         , ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Country
         , ref string City, ref string street)
        {
            bool IsFound = false;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                string query = "SP_GetUserByUserName";

                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Added CommandType
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@UserName", Username);

                    try
                    {
                        connection.Open();

                        // Added using for SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                IsFound = true;

                                User_ID = (int)reader["User_ID"];
                                Password = (string)reader["Password"];
                                Permissions = (int)reader["Permissions"];
                                Person_ID = (int)reader["Person_ID"];
                                FirstName = (string)reader["FirstName"];
                                LastName = (string)reader["LastName"];
                                Email = (string)reader["Email"];
                                Phone = (string)reader["Phone"];
                                Country = (string)reader["Country"];
                                City = (string)reader["City"];
                                street = (string)reader["street"];
                            }
                        } // SqlDataReader disposed here
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here


            return IsFound;
        }


        public static bool AddNew_User(ref int User_ID,string Username,string Password,int Permissions,ref int Person_ID,
            string FirstName,string LastName,string Email,string Phone,string Country,string City,string Street)
        {
            bool isAdded = false;

            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Input parameters for Person
                command.Parameters.AddWithValue("@FirstName", FirstName);
                command.Parameters.AddWithValue("@LastName", LastName);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Phone", Phone);
                command.Parameters.AddWithValue("@Country", Country);
                command.Parameters.AddWithValue("@City", City);
                command.Parameters.AddWithValue("@Street", Street);

                // Input parameters for User
                command.Parameters.AddWithValue("@UserName", Username);
                command.Parameters.AddWithValue("@Password", Password);
                command.Parameters.AddWithValue("@Permissions", Permissions);

                // Output parameters
                var pPersonID = new SqlParameter("@NewPersonID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                var pUserID = new SqlParameter("@NewUserID", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(pPersonID);
                command.Parameters.Add(pUserID);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();

                    // Assign returned values
                    if (pPersonID.Value != DBNull.Value && pUserID.Value != DBNull.Value)
                    {
                        Person_ID = (int)pPersonID.Value;
                        User_ID = (int)pUserID.Value;
                        isAdded = true;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    isAdded = false;
                }
            }

            return isAdded;
        }



        public static bool Update_User(int User_ID, int Person_ID, string Username, string Password, int Permissions,
       string FirstName, string LastName, string Email, string Phone, string Country, string City, string Street)
        {
            int RowsEffected = 0;

            // Added using for SqlConnection
            using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
            {
                // we update persons and users accordingly
                string query = "SP_UpdateUser";

                // Added using for SqlCommand
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Added CommandType
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", LastName);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@Phone", Phone);
                    command.Parameters.AddWithValue("@Country", Country);
                    command.Parameters.AddWithValue("@City", City);
                    command.Parameters.AddWithValue("@Street", Street);
                    command.Parameters.AddWithValue("@User_ID", User_ID);


                    command.Parameters.AddWithValue("@Person_ID", Person_ID);
                    command.Parameters.AddWithValue("@UserName", Username);
                    command.Parameters.AddWithValue("@Password", Password);
                    command.Parameters.AddWithValue("@Permissions", Permissions);

                    try
                    {
                        connection.Open();

                        RowsEffected = command.ExecuteNonQuery();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error : " + ex.Message);
                    }
                    // Removed finally block as requested
                } // SqlCommand disposed here
            } // SqlConnection closed and disposed here


            return (RowsEffected > 0);
        }

        public static bool Delete_User_By_ID(int User_ID)
        {
            int RowsAffected = 0;
            string query = "SP_DeleteUserByID";

            try
            {
                using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@User_ID", User_ID);

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


        public static DataTable Get_All_Users()
        {
            // The DataTable to hold the results
            DataTable dt = new DataTable();

            // Use a try-catch block to handle errors outside the resource management
            try
            {
                // 1. Use 'using' for SqlConnection
                using (SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString))
                {
                    string procedureName = "SP_GetAllUsers";

                    // 2. Use 'using' for SqlCommand
                    using (SqlCommand command = new SqlCommand(procedureName, connection))
                    {
                        // CRITICAL FIX: Tell the command that the text is a Stored Procedure
                        command.CommandType = CommandType.StoredProcedure;

                        connection.Open();

                        // 3. Use 'using' for SqlDataReader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Load the data directly into the DataTable
                                dt.Load(reader);
                            }
                        } // SqlDataReader is closed and disposed here

                    } // SqlCommand is disposed here

                } // SqlConnection is closed and disposed here
            }
            catch (Exception ex)
            {
                // Log the error
                Console.WriteLine("Error: " + ex.Message);

                // On error, return null or an empty DataTable
                return null;
            }

            return dt;
        }
   

        public static bool Is_User_Exist(int User_ID)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select found=1 from Users where User_ID = @User_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@User_ID", User_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                IsFound = reader.HasRows;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool Is_User_Exist(string UserName)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select found=1 from Users where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

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


        public static DataTable Get_All_Users_Log()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Users_login_log_View;";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                connection.Close();
                return null;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static DataTable Get_All_Users_Log_By_UserName(string UserName)
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Users_login_log_View where UserName = @UserName;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", UserName);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                connection.Close();
                return null;
            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        static public bool Add_User_Log(int User_ID , DateTime Login_Date)
        {
            bool Added = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            
            string query = @"INSERT INTO Login_Log
                            ([User_ID],[Login_Date])
                             VALUES
                             (@User_ID,@Login_Date)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@User_ID", User_ID);
            command.Parameters.AddWithValue("@Login_Date", Login_Date);


            try
            {
                connection.Open();

               Added =  (command.ExecuteNonQuery()) > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Added;

        }

    }
}
