using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Bank_Business_Layer;

namespace Bank_Presentation_Layer_ConsoleApp
{
    internal class Bank_ConsoleApp
    {

        static private void _Test_Find_Client_By_ID(int Client_ID)
        {

            clsClient client = clsClient.Find(Client_ID);


            if (client != null)
            {
                Console.WriteLine("Client " + client.Client_ID + " Info : ");

                Console.WriteLine($"Client ID       = {client.Client_ID}");
                Console.WriteLine($"Person_ID       = {client.Person_ID}");
                Console.WriteLine($"Account Number  = {client.AccountNumber}");
                Console.WriteLine($"PinCode         = {client.PinCode}");
            }
            else
                Console.WriteLine("Client " + Client_ID + " is NOT found");


            

        }

        static private void _Test_Find_Client_By_AccountNumber(string AccountNumber)
        {

            clsClient client = clsClient.Find(AccountNumber);


            if (client != null)
            {
                Console.WriteLine("Client " + client.Client_ID + " Info : ");

                Console.WriteLine($"Client ID       = {client.Client_ID}");
                Console.WriteLine($"Person_ID       = {client.Person_ID}");
                Console.WriteLine($"Account Number  = {client.AccountNumber}");
                Console.WriteLine($"PinCode         = {client.PinCode}");
            }
            else
                Console.WriteLine("Client with accountNumber " + AccountNumber + " is NOT found");

        }

        static private void _Test_Add_New_Client()
        {
            clsClient client = new clsClient();

            client.PinCode = "0000";
            client.Balance = 8000;
            client.FirstName = "daniel";
            client.LastName = "oxfoard";
            client.Email = "dainiel@gmail.com";
            client.Phone = "9287455335";
            client.country = "USA";
            client.City = "California";
            client.Street = "2 king street";




            if (client.Save())
                Console.WriteLine("Client add sucessfully, Client ID : " + client.Client_ID);
            else
                Console.WriteLine("Client adding Failed");



        }

        static private void _Test_Delete_Client(int Client_ID)
        {
            clsClient client = clsClient.Find(Client_ID);


            if (client != null && client.Delete())
                Console.WriteLine("Client with Client_ID : " + Client_ID + " has been deleted sucessfully");
            else
                Console.WriteLine("Error : Client with Client_ID : " + Client_ID + "  is NOT deleted");


        }

        static private void _Test_Update_Client(int Client_ID)
        {
            clsClient client = clsClient.Find(Client_ID);

            if (client == null)
            {
                Console.WriteLine("Client with Client_ID : " + Client_ID + " is NOT found");
                return;
            }

            client.PinCode = "1111";
            client.Balance = 0;
            client.FirstName = "ashraf";
            client.LastName = "hakimi";
            client.Email = "ashraf@gmail.com";
            client.Phone = "01410446546";
            client.country = "UK";
            client.City = "Manchster";
            client.Street = " king robertstreet";

            if (client.Save())
                Console.WriteLine("Client with Client_ID : " + Client_ID + " is Updated Successfully");
            else
                Console.WriteLine(" Error : Client with Client_ID : " + Client_ID + " is NOT Updated");



        }

        static private void _Test_Get_All_Clients()
        {
            DataTable dt = clsClient.Get_All_Clients();

            foreach (DataRow dr in dt.Rows)
            {

                Console.WriteLine($"{dr["Client_ID"]} , {dr["Person_ID"]} , {dr["AccountNumber"]},{dr["PinCode"]}," +
                    $"{dr["Balance"]},{dr["FirstName"]},{dr["LastName"]},{dr["Email"]},{dr["Phone"]},{dr["Country"]}," +
                    $"{dr["City"]},{dr["Street"]}");

            }

        }

        static private bool _Test_Is_Client_Exist(int Client_ID)
        {
            if (clsClient.Is_Client_Exist(Client_ID))
            {
                Console.WriteLine("Yes , Client : " + Client_ID + " Exists");
                return true;
            }
            else
                Console.WriteLine("No , Client : " + Client_ID + " Does NOT Exist");

            return false;
        }


        // ----------------------------------------------------------------------------------------------------

        static private void _Test_Find_User_By_ID(int User_ID)
        {
            clsUser user = clsUser.Find(User_ID);

            if(user != null)
            {
                Console.WriteLine("User  : " + user.User_ID + " Info :");

                Console.WriteLine("UserName   : " + user.UserName);
                Console.WriteLine("Password   : " + user.Password);
                Console.WriteLine("Permssions : " + user.Permissions);
            }
            else
            {
                Console.WriteLine("Error : User " + User_ID + " Is NOT found");
            }
        }

        static private void _Test_Find_User_By_UserName(string UserName)
        {
            clsUser user = clsUser.Find(UserName);

            if (user != null)
            {
                Console.WriteLine("User  : " + user.User_ID + " Info :");

                Console.WriteLine("UserName   : " + user.UserName);
                Console.WriteLine("Password   : " + user.Password);
                Console.WriteLine("Permssions : " + user.Permissions);
            }
            else
            {
                Console.WriteLine("Error : User " + UserName + " Is NOT found");
            }
        }
        
        static private void _Test_AddNew_User()
        {
            clsUser user = new clsUser();

            user.UserName = "admin.mesut";
            user.Password = "0000";
            user.Permissions = -1;

            user.FirstName = "mesut";
            user.LastName = "ozel";
            user.Email = "mesut@gmai.com";
            user.Phone = "064160102";
            user.country = "turkey";
            user.City = "izmir";
            user.Street = "beyazsaray street";


            if (user.Save())
            {
                Console.WriteLine("User saved successfully , new User_ID is : " + user.User_ID);
            }
            else
            {
                Console.WriteLine("Error User is NOT Saved ");
            }


        }

        static private void _Test_Update_User()
        {
            clsUser user = clsUser.Find(1);

            if(user != null)
            {
                user.UserName = "admin.ali";
                user.Password = "0000";
                user.Permissions = -1;

                user.FirstName = "Ali";
                user.LastName = "Ammar";
                user.Email = "Ali.Ammar@gmai.com";
                user.Phone = "025652165";
                user.country = "USA";
                user.City = "Los Angles";
                user.Street = "20 king venue";


                if (user.Save())
                {
                    Console.WriteLine("User Updated successfully ");
                }
                else
                {
                    Console.WriteLine("Error User is NOT Updated ");
                }
            }
        }


        static private void _Test_Delete_User(int User_ID)
        {
            


            if (clsUser.Delete_User(User_ID))
            {
               
                Console.WriteLine("User : " + User_ID + " Is Deleted Successfully");
            }
            else
                Console.WriteLine("Error :  User " + User_ID + " was NOT Deleted");
        }

        static private void _Test_Get_All_Users()
        {
            DataTable dt = clsUser.Get_All_Users();


            foreach(DataRow dr in dt.Rows)
            {
                Console.WriteLine($"{dr["FirstName"]}, {dr["Username"]}");
            }
        }

        static private bool _Test_Is_User_Exist(int User_ID)
        {
            if (clsUser.Is_User_Exist(User_ID))
            {
                Console.WriteLine("Yes , User : " + User_ID + " Exists");
                return true;
            }
            else
                Console.WriteLine("No , User : " + User_ID + " Does NOT Exist");

            return false;
        }



        //-------------------------------------------------------------------

        static private void _Test_Find_Transaction_By_ID(int Transaction_ID)
        {
            clsTransaction transaction = clsTransaction.Find(Transaction_ID);

            if(transaction != null)
            {
                Console.WriteLine($"transaction ID         : {transaction.Transaction_ID}");
                Console.WriteLine($"transaction Type       : {transaction.Transaction_Type_ID}");
                Console.WriteLine($"transaction Date       : {transaction.Transaction_Date_Time}");
                Console.WriteLine($"transaction Sender_Acc  : {transaction.Sender_Acc}");
                Console.WriteLine($"transaction Receiver_ID: {transaction.Reciver_Acc}");
                Console.WriteLine($"transaction Amount     : {transaction.Amount}");
                Console.WriteLine($"transaction User_ID    : {transaction.User_ID}");
            }
        }

        static private void _Test_List_Transfers_By_User_ID(int User_ID)
        {
            DataTable dt = clsTransaction.List_Transfers_By_User_ID(User_ID);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["Transaction_ID"]} \t {row["Type_Name"]} {row["Date"]} \t " +
                    $" {row["Sender_Acc"]} \t {row["Receiver_ID"]} \t {row["Amount"]} \t" +
                    $" {row["User_ID"]} \t");
            }
        }

        static private void _Test_List_Transfers_By_Client_ID(int Client_ID)
        {
            DataTable dt = clsTransaction.List_Transfers_By_Client_ID(Client_ID);

            foreach (DataRow row in dt.Rows)
            {
                Console.WriteLine($"{row["Transaction_ID"]} \t {row["Type_Name"]} {row["Date"]} \t " +
                    $" {row["Sender_Acc"]} \t {row["Receiver_ID"]} \t {row["Amount"]} \t" +
                    $" {row["User_ID"]} \t");
            }
        }

        static private void _Test_Transfer(int Sender_ID ,int Receiver_ID , double Amount)
        {
            if(clsTransaction.Transfer(Sender_ID,Receiver_ID,Amount))
            {
                Console.WriteLine("Transfer Done Successfully");
            }
            else
            {
                Console.WriteLine("Transfer is NOT Done");
            }
        }

        static private void _Test_Deposit(int Deposit_To_Client_ID, double Amount)
        {
            if (clsTransaction.Deposit(Deposit_To_Client_ID, Amount))
            {
                Console.WriteLine("Deposit Done Successfully");
            }
            else
            {
                Console.WriteLine("Deposit is NOT Done");
            }
        }

        static private void _Test_Withdrawl(int Withdraw_From_Client_ID, double Amount)
        {
            if (clsTransaction.Withdrawl(Withdraw_From_Client_ID, Amount))
            {
                Console.WriteLine("Withdrawl Done Successfully");
            }
            else
            {
                Console.WriteLine("Withdrawl is NOT Done");
            }
        }

        static private void _Test_Add_Transaction()
        {
            clsTransaction CurrentTransaction = new clsTransaction();

            CurrentTransaction.Transaction_Type_ID = 1;
            CurrentTransaction.Sender_Acc = null;
            CurrentTransaction.Reciver_Acc =1;
            CurrentTransaction.Transaction_Date_Time = DateTime.Now;
            CurrentTransaction.User_ID = 1; // Update this later khaled by adding global clsUser user;
            CurrentTransaction.Amount = 100;

            if (CurrentTransaction.Add())
            {
                Console.WriteLine("Transaction has been Added Successfully");
            }

        }

        static private void _Test_Add_User_Log(int User_ID, DateTime Login_Date)
        {
           if( clsUser.Add_User_Log(User_ID, Login_Date))
            {
                Console.WriteLine("Log added Successfully");
            }
           else
            {
                Console.WriteLine("Addeing log failed");
            }
        }
        static void Main(string[] args)
        {

            //_Test_Add_New_Client();
            //_Test_Find_Client_By_ID(4);
            //_Test_Find_Client_By_AccountNumber("1003");
            //_Test_Delete_Client(4);
            //_Test_Update_Client(2);
            //_Test_Get_All_Clients();
            //_Test_Is_Client_Exist(1);
            //_Test_Is_Client_Exist(100);

            // ----------------------------------------------------------------------------

            _Test_Find_User_By_ID(1);
            //_Test_Find_User_By_UserName("Admin.ali");
            //_Test_AddNew_User();
            //_Test_Update_User();
            //_Test_Delete_User(15);
            //_Test_Is_User_Exist(1);
            //_Test_Is_User_Exist(100);
            //_Test_Get_All_Users();

            //----------------------------------------------------------------------------------

            //_Test_Find_Transaction_By_ID(2);
            //_Test_List_Transfers_By_User_ID(1);
            //_Test_List_Transfers_By_Client_ID(1);
            //_Test_Transfer(1, 2, 10);
            //_Test_Deposit(3, 100);
            //_Test_Withdrawl(1, 500);
            //_Test_Add_Transaction();

           // _Test_Add_User_Log(15, DateTime.Now);

            Console.ReadLine();
        }
    }
}
