using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Bank_Data_Layer;

namespace Bank_Business_Layer
{
    public class clsClient : clsPerson
    {
        public enum enMode { enAddNew = 0, enUpdate = 1 };

        public enMode Mode = enMode.enAddNew;


        public int Client_ID { get; private set; }
        public string AccountNumber { get; private set; }
        public string PinCode { get; set; }
        public double Balance { get; set; }

        /// <summary>
        /// returns an empty object of clsClient
        /// </summary>
        public clsClient() : base()
        {
            Mode = enMode.enAddNew;


            Client_ID = -1;
            AccountNumber = "";
            PinCode = "";
            Balance = 0.0;
        }
      
        private clsClient(int client_id, int person_id, string accountnumber, string pincode, double balance,
            string firstname, string lastname, string email, string phone, string country, string city, string street)
            : base(person_id, firstname, lastname, email, phone, country, city, street)
        {
            Mode = enMode.enUpdate;

            Client_ID = client_id;
            AccountNumber = accountnumber;
            PinCode = pincode;
            Balance = balance;

        }

        /// <summary>
        /// Finds a client based on their unique Client ID and retrieves their information from the data source.
        /// </summary>
        /// <param name="Client_ID">The unique identifier of the client to find.</param>
        /// <returns>
        /// A <see cref="clsClient"/> object containing the client's information if found; otherwise, returns null.
        /// </returns>
        /// <remarks>
        /// This method queries the data source to locate a client using the specified Client ID. If a matching client
        /// is found, their details are retrieved and returned as a <see cref="clsClient"/> object. If no client is found
        /// with the provided Client ID, the method returns null.
        /// </remarks>
        /// 
        

        
        public static clsClient Find(int Client_ID)
        {
            int Person_ID = -1;
            string AccountNumber = "";
            string pincode = "";
            double balance = 0.0;
            string firstname = "";
            string lastname = "";
            string email = "";
            string phone = "";
            string country = "";
            string city = "";
            string street = "";


            if (clsData_Client.Find_Client_By_ID(Client_ID, ref Person_ID, ref AccountNumber, ref pincode, ref balance,
                                                 ref firstname, ref lastname, ref email, ref phone, ref country, ref city, ref street))
            {
                return new clsClient(Client_ID, Person_ID, AccountNumber, pincode, balance,
                                       firstname, lastname, email, phone, country, city, street); ;
            }
            else
                return null;

        }

        /// <summary>
        /// Finds a client based on their unique AccountNumber and retrieves their information from the data source.
        /// </summary>
        /// <param name="AccountNumber">The unique identifier of the client to find.</param>
        /// <returns>
        /// A <see cref="clsClient"/> object containing the client's information if found; otherwise, returns null.
        /// </returns>
        /// <remarks>
        /// This method queries the data source to locate a client using the specified Client ID. If a matching client
        /// is found, their details are retrieved and returned as a <see cref="clsClient"/> object. If no client is found
        /// with the provided Client ID, the method returns null.
        /// </remarks>
        public static clsClient Find(string AccountNumber)
        {
            int Client_ID = -1;
            int Person_ID = -1;
            string pincode = "";
            double balance = 0.0;
            string firstname = "";
            string lastname = "";
            string email = "";
            string phone = "";
            string country = "";
            string city = "";
            string street = "";


            if (clsData_Client.Find_Client_By_AccountNumber(ref Client_ID, ref Person_ID, AccountNumber, ref pincode, ref balance,
                                                 ref firstname, ref lastname, ref email, ref phone, ref country, ref city, ref street))
            {
                return new clsClient(Client_ID, Person_ID, AccountNumber, pincode, balance,
                                       firstname, lastname, email, phone, country, city, street); ;
            }
            else
                return null;

        }


        private bool _Add_New_Client()
        {
            bool isAdd = false;
            int client_ID = -1;
            int person_ID = -1;
            string accountnumber = "";

            isAdd = clsData_Client.Add_New_Client
                 (this.PinCode, this.Balance, this.FirstName, this.LastName, this.Email, this.Phone, this.country, this.City,
                 this.Street, ref person_ID, ref client_ID, ref accountnumber);

            if (isAdd)
            {
                this.Client_ID = client_ID;
                this.Person_ID = person_ID;
                this.AccountNumber = accountnumber;

                Mode = enMode.enUpdate;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Deletes a client based on their unique Client ID from the data source.
        /// </summary>
        /// <param name="Client_ID">The unique identifier of the client to delete.</param>
        /// <returns>
        /// True if the client was successfully deleted; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method attempts to delete a client from the data source using the specified Client ID. If the deletion is
        /// successful, it returns true. If the deletion fails or the client with the provided Client ID does not exist,
        /// it returns false.
        /// </remarks>
        public bool Delete()
        { 
            return clsData_Client.Delete_Client_By_ID(this.Client_ID);
        }

        public static bool Delete_By_ID(int Client_ID)
        {
            return clsData_Client.Delete_Client_By_ID(Client_ID);
        }


        private bool _Update_Client()
        {
           return clsData_Client.Update_Client(this.Client_ID, this.PinCode, this.Balance, this.FirstName, this.LastName,
                                         this.Email, this.Phone, this.country, this.City, this.Street);
            
        }

        public static bool Is_Client_Exist(int Client_ID)
        {
            return clsData_Client.Is_Client_Exist(Client_ID);
        }



        public static DataTable Get_All_Clients()
        {
            return clsData_Client.Get_All_Clients();
        }


        /// <summary>
        /// Saves the current state of the client object to the data source based on its mode.
        /// </summary>
        /// <returns>
        /// True if the client data was successfully saved; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method is responsible for saving the current state of the client object to the data source based on its mode.
        /// If the client object is initialized using the default constructor <see cref="clsClient()"/>, it operates in 'eAddNew'
        /// mode, attempting to add a new client to the data source. If the client object is obtained using the <see cref="clsClient.Find(int)"/>
        /// function, it operates in 'eUpdate' mode, attempting to update an existing client's information. Returns true if the operation
        /// is successful, and false otherwise.
        /// </remarks>
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.enAddNew:
                    if (_Add_New_Client())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _Update_Client();
            }
            return false;
        }

    }
}
