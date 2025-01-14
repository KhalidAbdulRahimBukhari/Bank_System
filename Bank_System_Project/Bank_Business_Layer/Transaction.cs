using Bank_Data_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Business_Layer
{
    public class clsTransaction
    {

        public enum enType { eDeposit , eWithdrawl , eTransfer};

        
        public int Transaction_ID { get; private set; }
        public int Transaction_Type_ID { get; set; }

        public DateTime Transaction_Date_Time { get; set; }

        public TypeSmallDateTimeSchemaImporterExtension DateT { get; set; }
        public int? Sender_Acc { get; set; }
        public int? Reciver_Acc { get; set; }
        public int User_ID { get; set; }

        public double Amount { get; set; }

        public clsTransaction()
        {
            Transaction_ID = -1;
            Transaction_Type_ID = -1;
            Sender_Acc = null;
            Reciver_Acc = null;
            User_ID = -1;
            Amount = 0;
            Transaction_Date_Time = DateTime.Now;
        }
        private clsTransaction(int Transaction_ID , int Transaction_Type ,DateTime Transaction_Date_Time, int? Sender_Acc , int? Reciver_Acc , int User_ID , double Amount)
        {

            this.Transaction_ID = Transaction_ID;
            this.Transaction_Type_ID = Transaction_Type;
            this.Sender_Acc = Sender_Acc;
            this.Reciver_Acc = Reciver_Acc;
            this.User_ID = User_ID;
            this.Amount = Amount;
        }

        /// <summary>
        /// Search in DataBase for a Transaction by Transaction_ID
        /// </summary>
        /// <param name="Transaction_ID"></param>
        /// <returns>if Found  returns a Row has the the transaction details; if NOT found returns null </returns>
        public static clsTransaction Find(int Transaction_ID)
        {
            int Transaction_Type_ID = -1;
            DateTime Transaction_Date_Time = DateTime.Now;
            Nullable<int> Sender_ID = null;
            Nullable<int> Reciver_ID = null;
            int User_ID = -1;
            double Amount = 0;


            if (clsData_Transaction.Find_By_Transaction_ID(Transaction_ID, ref Transaction_Type_ID,ref Transaction_Date_Time, ref Sender_ID, ref Reciver_ID, ref User_ID, ref Amount))
            {
                return new clsTransaction(Transaction_ID, Transaction_Type_ID, Transaction_Date_Time, Sender_ID, Reciver_ID, User_ID, Amount);
            }
            else
                return null;
        }

        /// <summary>
        /// Search in the Database for Transfers done by a User_ID
        /// </summary>
        /// <param name="User_ID"></param>
        /// <returns>if Found returns Datatable of all transfers done by User_ID ; If NOT found returns empty Datatable </returns>
        public static DataTable List_Transfers_By_User_ID(int User_ID)
        {
            return clsData_Transaction.List_By_User_ID(User_ID);
        }
        public static DataTable List_Transfers_By_Client_AccountNumber(int AccountNumber)
        {
            return clsData_Transaction.List_Transfers_By_Client_AccountNumber(AccountNumber);
        }

        /// <summary>
        /// Search in the Database for Transfers done from Client_ID or to Client_ID
        /// </summary>
        /// <param name="User_ID"></param>
        /// <returns>if Found returns Datatable of all transfers done from Client_ID or to Client_ID ; If NOT found returns empty Datatable </returns>
        public static DataTable List_Transfers_By_Client_ID(int Client_ID)
        {
            return clsData_Transaction.List_By_Client_ID(Client_ID);
        }

        /// <summary>
        /// Performs a certain amount transfer from client to another client and apply changes in the Database
        /// </summary>
        /// <param name="Sender_Acc"></param>
        /// <param name="Reciver_Acc"></param>
        /// <param name="Amount"></param>
        /// <returns>True if Transfer is Successful ; False if Transfer Failed </returns>
        public static bool Transfer(int Sender_Acc, int Reciver_Acc , double Amount)
        {
           return clsData_Transaction.Transfer(Sender_Acc, Reciver_Acc, Amount);
        }

        /// <summary>
        /// Performs a certain amount Deposit to a Client and applies changes in the Database
        /// </summary>
        /// <param name="Deposit_To_Client_ID"></param>
        /// <param name="Amount"></param>
        /// <returns>True if Deposit is Successful ; False if Deposit Failed </returns>
        public static bool Deposit(int Deposit_To_Client_ID,double Amount)
        {
            return clsData_Transaction.Deposit(Deposit_To_Client_ID, Amount);
        }

        /// <summary>
        /// Performs a certain amount Withdrawl from a Client and applies changes in the Database
        /// </summary>
        /// <param name="Deposit_To_Client_ID"></param>
        /// <param name="Amount"></param>
        /// <returns>True if Withdrawl is Successful ; False if Withdrawl Failed </returns>
        public static bool Withdrawl(int Withdraw_From_Client_ID, double Amount)
        {
            return clsData_Transaction.Withdrawl(Withdraw_From_Client_ID, Amount);
        }

        public bool Add()
        {
            return clsData_Transaction.Add(this.Transaction_Type_ID, this.Transaction_Date_Time
                                                          , this.Sender_Acc, this.Reciver_Acc, this.Amount, this.User_ID);
        }

        public static DataTable Get_All_Transactions()
        {
            return clsData_Transaction.Get_All_Transactions();
        }



    }
}
