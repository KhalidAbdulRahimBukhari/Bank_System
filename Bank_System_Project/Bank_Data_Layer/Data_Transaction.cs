using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Data_Layer
{
    public class clsData_Transaction
    {

        public static bool Find_By_Transaction_ID(int Transaction_ID,ref int Transaction_Type_ID,
                                ref DateTime Date, ref Nullable<int> Sender_Acc,
                               ref Nullable<int> Receiver_Acc, ref int User_ID, ref double Amount)
        {
            bool IsFound = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = "select * from Transactions where Transaction_ID = @Transaction_ID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Transaction_ID", Transaction_ID);


            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();


                if (reader.Read())
                {
                    IsFound = true;


                    Transaction_Type_ID = (int)reader["Transaction_Type_ID"];
                    Date = (DateTime)reader["Date"];

                    if (reader["Sender_Acc"] != DBNull.Value)
                    {
                        Sender_Acc = (int)reader["Sender_Acc"];
                    }
                    else
                    {
                        Sender_Acc = null;
                    }

                    if (reader["Receiver_Acc"] != DBNull.Value)
                    {
                        Sender_Acc = (int)reader["Receiver_Acc"];
                    }
                    else
                    {
                        Receiver_Acc = null;
                    }

                    Amount = (double)reader["Amount"];
                    User_ID = (int)reader["User_ID"];

                }
                else
                    IsFound = false;


            }
            catch(Exception ex)
            {
                //string filePath = @"C:\Users\90552\Desktop\Error.File.txt";
 

                //    using (StreamWriter writer = new StreamWriter(filePath, true))
                //{
                //    writer.WriteLine("-----------------------------------------------------------------------------");
                //    writer.WriteLine("Date : " + DateTime.Now.ToString());
                //    writer.WriteLine();

                //    while (ex != null)
                //    {
                //        writer.WriteLine(ex.GetType().FullName);
                //        writer.WriteLine("Message : " + ex.Message);
                //        writer.WriteLine("StackTrace : " + ex.StackTrace);

                //        ex = ex.InnerException;
                //    }
                //}
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }



        public static DataTable List_By_User_ID(int User_ID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Transaction_View where User_ID = @User_ID order by Date desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@User_ID", User_ID);


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
                Console.WriteLine("Error : " + ex.StackTrace);
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return dt;
          
        }

        public static DataTable List_Transfers_By_Client_AccountNumber(int AccountNumber)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Transaction_View where Sender_Acc = @AccountNumber or Receiver_Acc = @AccountNumber  order by Date desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@AccountNumber", AccountNumber);


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
                Console.WriteLine("Error : " + ex.StackTrace);
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return dt;

        }


        public static DataTable List_By_Client_ID(int Client_ID)
        {

            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Transaction_View
                               where Sender_Acc = @Client_ID or Receiver_Acc = @Client_ID
                                  order by Date desc";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Client_ID", Client_ID);


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
            }
            finally
            {
                connection.Close();
            }


            return dt;

        }


        public static bool Transfer(int Sender_Acc , int Reciver_Acc , double Amount)
        {
            bool IsTransfered = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"update Clients 
                           set Balance = Balance - @Amount
                            where Client_ID = @Sender_Acc 

                           update Clients 
                            set Balance = Balance + @Amount
                            where Client_ID = @Receiver_Acc ";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Sender_Acc", Sender_Acc);
            command.Parameters.AddWithValue("@Receiver_Acc", Reciver_Acc);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 1)
                    IsTransfered = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsTransfered;
        }


        public static bool Deposit(int Deposit_To_Client_ID, double Amount)
        {
            bool IsTransfered = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"update Clients 
                            set Balance = Balance + @Amount
                            where Client_ID = @Deposit_To_Client_ID ";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Deposit_To_Client_ID", Deposit_To_Client_ID);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 0)
                    IsTransfered = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsTransfered;
        }

        public static bool Withdrawl(int Withdraw_From_Client_ID, double Amount)
        {
            bool IsTransfered = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"update Clients 
                            set Balance = Balance - @Amount
                            where Client_ID = @Withdraw_From_Client_ID ";

            SqlCommand command = new SqlCommand(@query, connection);

            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@Withdraw_From_Client_ID", Withdraw_From_Client_ID);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 0)
                    IsTransfered = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsTransfered;
        }

        public static bool Add(int Transaction_Type_ID,DateTime Date, Nullable<int> Sender_Acc,
                                                 Nullable<int> Receiver_Acc ,double Amount ,int User_ID)
        {
            bool IsAdded = false;


            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"INSERT INTO Transactions
                           (Transaction_Type_ID,Date,Sender_Acc,Receiver_Acc,Amount,User_ID)
                           VALUES
                          (@Transaction_Type_ID,@Date,@Sender_Acc,@Receiver_Acc,@Amount,@User_ID)";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Transaction_Type_ID", Transaction_Type_ID);
            command.Parameters.AddWithValue("@Date", Date);

            if(Sender_Acc != null)
            {
                command.Parameters.AddWithValue("@Sender_Acc", Sender_Acc);
            }
            else
            {
                command.Parameters.AddWithValue("@Sender_Acc", DBNull.Value);
            }
            if (Receiver_Acc != null)
            {
                command.Parameters.AddWithValue("@Receiver_Acc", Receiver_Acc);
            }
            else
            {
                command.Parameters.AddWithValue("@Receiver_Acc", DBNull.Value);
            }
            command.Parameters.AddWithValue("@Amount", Amount);
            command.Parameters.AddWithValue("@User_ID", User_ID);

            try
            {
                connection.Open();

                int RowsAffected = command.ExecuteNonQuery();

                if (RowsAffected > 0)
                    IsAdded = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }
            finally
            {
                connection.Close();
            }


            return IsAdded;
        }

        public static DataTable Get_All_Transactions()
        {
            DataTable dt = new DataTable();

            SqlConnection connection = new SqlConnection(clsData_Access_Settings.ConnectionString);

            string query = @"select * from Transaction_View;";

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

    }
}
