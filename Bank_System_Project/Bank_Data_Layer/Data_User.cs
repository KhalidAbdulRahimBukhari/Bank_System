using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer
{
    public class clsData_User
    {
        public static bool Find_By_User_ID(int User_ID, ref string Username, ref string Password, ref int Permissions, ref int Person_ID
               , ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Country
               , ref string City, ref string street)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from UserPersonView
                            where User_ID = @User_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@User_ID", User_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
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



        public static bool Find_By_UserName(ref int User_ID, string Username, ref string Password, ref int Permissions, ref int Person_ID
              , ref string FirstName, ref string LastName, ref string Email, ref string Phone, ref string Country
              , ref string City, ref string street)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from UserPersonView
                            where UserName = @UserName";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@UserName", Username);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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


        public static bool AddNew_User(ref int User_ID, string Username, string Password, int Permissions,
            ref int Person_ID, string FirstName, string LastName, string Email, string Phone,
            string Country, string City, string Street)
        {
            int Changes = 0;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            // First we add person and get Automatic Person_ID using Scope_Identity and ExcuteScalar 
            string query = @"INSERT INTO Persons
                            ([FirstName],[LastName],[Email],[Phone],[Country],[City],[Street])
                          VALUES
                                (@FirstName,@LastName,@Email,@Phone,@Country,@City,@Street)
		                         select top 1 SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName",LastName);
            command.Parameters.AddWithValue("@Email",Email);
            command.Parameters.AddWithValue("@Phone",Phone);
            command.Parameters.AddWithValue("@Country",Country);
            command.Parameters.AddWithValue("@City",City);
            command.Parameters.AddWithValue("@Street",Street);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(), out int ID ))
                {
                    Person_ID = ID;
                    Changes++;
                }

                // Second we add user and we get the new User_ID and we assign it 
                string query_To_Add_User = @"INSERT INTO Users
                                            ([Person_ID],[UserName],[Password],[Permissions])
                                            VALUES
                                                  (@Person_ID,@UserName,@Password,@Permissions)
	                                   	    select top 1 SCOPE_IDENTITY();";

                command = new SqlCommand(query_To_Add_User, connection);
                command.Parameters.AddWithValue("@Person_ID",Person_ID);
                command.Parameters.AddWithValue("@UserName",Username);
                command.Parameters.AddWithValue("@Password",Password);
                command.Parameters.AddWithValue("@Permissions",Permissions);
                
                
                object result2 = command.ExecuteScalar();

                if( result2 != null && int.TryParse(result2.ToString(), out int ID2 ))
                {
                    User_ID = ID2;
                    Changes++;
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return Changes > 1;
        }


        public static bool Update_User(int User_ID , int Person_ID ,string Username, string Password, int Permissions,
           string FirstName, string LastName, string Email, string Phone, string Country, string City, string Street)
        {
            int RowsEffected = 0;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);


            // we update persons and users accordingly
            string query = @"UPDATE Persons
                                             SET
                                                 [FirstName] = @FirstName
                                                ,[LastName] = @LastName
                                                ,[Email] = @Email
                                                ,[Phone] = @Phone
                                                ,[Country] = @Country
                                                ,[City] = @City
                                                ,[Street] = @Street
                                            WHERE Person_ID = (select Users.Person_ID from Users where User_ID = @User_ID);

                                             UPDATE Users
                                                        SET 
                                                            [Person_ID] = @Person_ID
                                                           ,[UserName] = @UserName
                                                           ,[Password] = @Password
                                                           ,[Permissions] = @Permissions
                                                      WHERE User_ID = @User_ID ";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName",FirstName);
            command.Parameters.AddWithValue("@LastName",LastName);
            command.Parameters.AddWithValue("@Email",Email);
            command.Parameters.AddWithValue("@Phone",Phone);
            command.Parameters.AddWithValue("@Country",Country);
            command.Parameters.AddWithValue("@City",City);
            command.Parameters.AddWithValue("@Street",Street);
            command.Parameters.AddWithValue("@User_ID",User_ID);


            command.Parameters.AddWithValue("@Person_ID",Person_ID);
            command.Parameters.AddWithValue("@UserName",Username);
            command.Parameters.AddWithValue("@Password",Password);
            command.Parameters.AddWithValue("@Permissions",Permissions);

            try
            {
                connection.Open();

                RowsEffected = command.ExecuteNonQuery();

            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return (RowsEffected > 0 );
        }

        public static bool Delete_User_By_ID(int User_ID)
        {
            int Changes = 0;
            int Person_ID = -1;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            // query to get Person_ID and save it to use it later on
            string query_to_get_Person_ID = @"select Persons.Person_ID from Persons where Person_ID = (select Users.Person_ID from Users where User_ID =@User_ID);";

            SqlCommand command = new SqlCommand(query_to_get_Person_ID, connection);

            command.Parameters.AddWithValue("@User_ID", User_ID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if(result != null && int.TryParse(result.ToString(),out int ID))
                {
                    Person_ID = ID;
                    Changes++;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            // query to delete user first the delete person accordingly due to FK_Users_Persons constraint
            string query = @"Delete from Users where User_ID = @User_ID;
                              Delete from Persons where Person_ID = @Person_ID ";
            SqlCommand command_2 = new SqlCommand(query, connection);

            command_2.Parameters.AddWithValue("@User_ID", User_ID);
            command_2.Parameters.AddWithValue("@Person_ID", Person_ID);

            try
            {
                int RowsEffected = command_2.ExecuteNonQuery();

                if(RowsEffected > 1)
                {
                    Changes++;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return (Changes > 1);
        }


        public static DataTable Get_All_Users()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from UserPersonView;";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if(reader.HasRows)
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
