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


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = "select * from ClientPersonView where Client_ID = @Client_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Client_ID", Client_ID);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error : " +  ex.Message);
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

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

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = "select * from ClientPersonView where AccountNumber = @AccountNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

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


        /// <summary>
        /// Adding new Client to Data Base and geting the person ID and the Client ID also creating an accountnumber
        /// </summary>
        /// <returns> true if added successfully, false if not added  </returns>
        public static bool Add_New_Client
            (string PinCode, double Balance
            , string firstname, string lastname, string email,
             string phone, string country, string city, string street
            , ref int New_Person_ID, ref int New_Client_ID, ref string AccountNumber)
        {
            int changes = 0;

            // Add Person and get the new person identity
            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"INSERT INTO Persons
                           (FirstName,LastName,Email,Phone,Country,City,Street)
                            VALUES
                             (@FirstName,@LastName,@Email,@Phone,@Country,@City,@Street)
                               select top 1 SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Country", country);
            command.Parameters.AddWithValue("@City", city);
            command.Parameters.AddWithValue("@Street", street);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int ID))
                {
                    New_Person_ID = ID;
                    changes++;
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error : " + ex.Message);
            }



            //Add 1000 to Person ID  and assign it to account number
            AccountNumber = (New_Person_ID + 1000).ToString();





            // Add Client and get the new client identity
            string query_2 = @"INSERT INTO Clients
                               (Person_ID,AccountNumber,PinCode,Balance)
                               VALUES
                               (@Person_ID,@AccountNumber,@PinCode,@Balance)
	                           select top 1 SCOPE_IDENTITY();";

            SqlCommand command_2 = new SqlCommand(query_2, connection);

            command_2.Parameters.AddWithValue("@Person_ID", New_Person_ID);
            command_2.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command_2.Parameters.AddWithValue("@PinCode", PinCode);
            command_2.Parameters.AddWithValue("@Balance", Balance);

            try
            {

                object result_2 = command_2.ExecuteScalar();

                if (result_2 != null && int.TryParse(result_2.ToString(), out int ID))
                {
                    New_Client_ID = ID;
                    changes++;
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



            return (changes > 1);
        }

        public static bool Add_New_Client_Using_3_Queries
            (string PinCode, double Balance
            , string firstname, string lastname, string email,
             string phone, string country, string city, string street
            , ref int New_Person_ID, ref int New_Client_ID, ref string AccountNumber)
        {
            bool IsAdded = false;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"INSERT INTO Persons
                              (FirstName,LastName,Email,Phone,Country,City,Street)
                            VALUES
	                          (@FirstName,@LastName,@Email,@Phone,@Country,@City,@Street)
                            INSERT INTO Clients
                              (Person_ID,AccountNumber,PinCode,Balance)
                            VALUES
                              ((select top 1 SCOPE_IDENTITY() from Persons),@AccountNumber,@PinCode,@Balance)
                                select top 1 SCOPE_IDENTITY() from Clients";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FirstName", firstname);
            command.Parameters.AddWithValue("@LastName", lastname);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Phone", phone);
            command.Parameters.AddWithValue("@Country", country);
            command.Parameters.AddWithValue("@City", city);
            command.Parameters.AddWithValue("@Street", street);
            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);
            command.Parameters.AddWithValue("@PinCode", PinCode);
            command.Parameters.AddWithValue("@Balance", Balance);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    New_Client_ID = Convert.ToInt32(result);
                    IsAdded = true;
                }


                // guery to assign Person ID

                string query_to_get_assigned_Person_ID = "select Clients.Person_ID from Clients where Client_ID = @Client_ID";

                command = new SqlCommand(query_to_get_assigned_Person_ID, connection);

                command.Parameters.AddWithValue("@Client_ID", New_Client_ID);

                New_Person_ID = Convert.ToInt32(command.ExecuteScalar());

                // set account number by adding 1000 to client ID
                AccountNumber = (New_Client_ID + 1000).ToString();

                // query to update account number

                string query_to_update_accountnumber = @"Update clients 
                                                         set AccountNumber = @AccountNumber
                                                           where Client_ID = @Client_ID;";

                SqlCommand command_to_Set_AccountNumber = new SqlCommand(query_to_update_accountnumber, connection);

                command_to_Set_AccountNumber.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                command_to_Set_AccountNumber.Parameters.AddWithValue("@Client_ID", New_Client_ID);

                IsAdded = (command_to_Set_AccountNumber.ExecuteNonQuery()) > 0;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
                IsAdded = false;
            }
            finally
            {
                connection.Close();
            }


            return IsAdded;
        }


        public static bool Update_Client(int Client_ID, string PinCode, double Balance
            , string firstname, string lastname, string email,
             string phone, string country, string city, string street)
        {
            bool IsUpdated = false;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            // we have to update each person info and client info seperately becuase they are 2 different tables

            string query = @"UPDATE Persons
                                             SET
                                                 [FirstName] = @FirstName
                                                ,[LastName] = @LastName
                                                ,[Email] = @Email
                                                ,[Phone] = @Phone
                                                ,[Country] = @Country
                                                ,[City] = @City
                                                ,[Street] = @Street
                                            WHERE
                                              Person_ID = (select Clients.Person_ID from Clients where Client_ID = @Client_ID);
                                              UPDATE Clients
                                                 SET 
                                                     [PinCode] = @PinCode
                                                    ,[Balance] = @Balance
                                               WHERE
                                                     Client_ID = @Client_ID;";


            SqlCommand command = new SqlCommand(query, connection);

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
            finally
            {
                connection.Close();
            }


            return IsUpdated;
        }


        public static bool Delete_Client_By_ID(int Client_ID)
        {
            bool isDeleted = false;

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            // first we get person id to use it later on
            string query_to_get_Person_ID = "select Persons.Person_ID from Persons where Person_ID = (select Clients.Person_ID from clients where Client_ID = @Client_ID)";

            SqlCommand command = new SqlCommand(query_to_get_Person_ID, connection);

            command.Parameters.AddWithValue("@Client_ID", Client_ID);

            try
            {
                connection.Open();

                int Person_ID = Convert.ToInt32(command.ExecuteScalar());


                // second we delete client , because person cannot be deleted before client due to FK constraint
                string query_to_delete_Client = " delete from Clients where Client_ID = @Client_ID";

                command = new SqlCommand(query_to_delete_Client, connection);
                command.Parameters.AddWithValue("@Client_ID", Client_ID);

                // check if row effected hence client deleted , assign it to the boolean IsDeleted
                isDeleted = (command.ExecuteNonQuery()) > 0;


                // finally delete person related to the client
                string query_to_delete_Person = "delete from Persons where Person_ID = @Person_ID";

                command = new SqlCommand(query_to_delete_Person, connection);
                command.Parameters.AddWithValue("@Person_ID", Person_ID);

                // check if row effected hence Person deleted , assign it to the boolean IsDeleted
                isDeleted = (command.ExecuteNonQuery()) > 0;


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return isDeleted;
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


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from ClientPersonView";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader read = command.ExecuteReader();

                if (read.HasRows)
                {
                    dt.Load(read);
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error : " + ex.Message);
                //connection.Close();
                //return null;
            }
            finally
            {
                connection.Close();
            }

            return dt;

        }



    }
}
