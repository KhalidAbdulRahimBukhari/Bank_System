using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bank_Data_Layer;

namespace Bank_Business_Layer
{
    public class clsUser : clsPerson
    {
        public int User_ID { get; private set; }
        public string UserName { get; set; }

        public string Password { get; set; }    

        public int Permissions { get; set; }

        public enum enMode { enAddNew = 0, enUpdate = 1 }

        enMode Mode = enMode.enAddNew;

        /// <summary>
        /// When you create an object using the constructor,
        /// then use the <c>Save()</c> method,
        /// the information on this object will be stored on new row on the database
        /// </summary>
        public clsUser() : base()
        {
            Mode = enMode.enAddNew;


            User_ID = -1;
            UserName = "";
            Password = "";
            Permissions = 0;
        }

        /// <summary>
        /// When you create an object using the constructor,
        /// then use the <c>Save()</c> method,
        /// the information on this object will overriding the information of the user with <c>user_ID</c> (Perform update operation)
        /// </summary>
        /// <param name="User_ID">the unique identifire of the user</param>
        /// <param name="Person_ID">the uniqye identifire if the person</param>
        /// <param name="Permissions">an <c>integer number</c> represent the user permission as <c>flags</c> , every bit on this integer tell if he have the permission to do something (1) or not (0)</param>
        private clsUser(int User_ID, string Username, string Password, int Permissions,
            int Person_ID, string FirstName, string LastName, string Email, string Phone, string Country, string City, string Street)
            : base(Person_ID, FirstName, LastName, Email, Phone, Country, City, Street)
        {
            this.User_ID = User_ID;
            this.UserName = Username;
            this.Password = Password;
            this.Permissions = Permissions;

            Mode = enMode.enUpdate;
        }

        /// <summary>
        /// Retrieves a user by their unique User_ID.
        /// </summary>
        /// <param name="User_ID">The unique identifier of the user.</param>
        /// <returns>The user object if found; otherwise, null.</returns>
        public static clsUser Find(int User_ID)
        {
            string UserName = "";
            string Password = "";
            int Permissions = 0;

            int Person_ID = -1;
            string firstname = "";
            string lastname = "";
            string email = "";
            string phone = "";
            string country = "";
            string city = "";
            string street = "";

            if (clsData_User.Find_By_User_ID(User_ID, ref UserName, ref Password, ref Permissions, ref Person_ID, ref firstname
                , ref lastname, ref email, ref phone, ref country, ref city, ref street))
            {
                return new clsUser(User_ID, UserName, Password, Permissions, Person_ID,
                    firstname, lastname, email, phone, country, city, street);
            }
            else
                return null;



        }

        public static clsUser Find(string UserName)
        {
            int User_ID = -1;
            string Password = "";
            int Permissions = 0;

            int Person_ID = -1;
            string firstname = "";
            string lastname = "";
            string email = "";
            string phone = "";
            string country = "";
            string city = "";
            string street = "";

            if (clsData_User.Find_By_UserName(ref User_ID, UserName, ref Password, ref Permissions, ref Person_ID, ref firstname
                , ref lastname, ref email, ref phone, ref country, ref city, ref street))
            {
                return new clsUser(User_ID, UserName, Password, Permissions, Person_ID,
                    firstname, lastname, email, phone, country, city, street);
            }
            else
                return null;

        }


        private bool _AddNew_User()
        {
            bool IsAdded = false;
            int User_ID = -1;
            int Person_ID = -1;

            IsAdded = clsData_User.AddNew_User(ref User_ID, UserName, Password,Permissions,
                                               ref Person_ID, FirstName, LastName, Email, Phone, country,City, Street);

            if (IsAdded)
            {
                this.User_ID = User_ID;
                this.Person_ID = Person_ID;
                return true;
            }
            else
                return false;
            

        }

        private bool _Update_User()
        {
            return clsData_User.Update_User(User_ID,Person_ID,UserName,Password,Permissions,FirstName,LastName,Email
                ,Phone, country,City,Street);
        }

        /// <summary>
        /// Saves the user's information to the database.
        /// </summary>
        /// <returns>True if the save operation is successful; otherwise, false.</returns>
        /// <remarks>
        /// If the user object is created using the <see cref="clsUser.Find(int)"/> method,
        /// this function will update the user's information in the database. If the user object
        /// is created using the default constructor <see cref="clsUser()"/>, it will add a new user
        /// to the database. Subsequent calls will update the existing user's information.
        /// </remarks>
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.enAddNew:
                    if (_AddNew_User())
                    {
                        Mode = enMode.enUpdate;
                        return true;
                    }
                    else
                        return false;

                case enMode.enUpdate:
                    return _Update_User();
            }

            return false;
        }

        /// <summary>
        /// Deletes a user.
        /// </summary>
        /// <param name="User_ID">The unique identifier of the user to delete.</param>
        /// <returns>True if the user is deleted successfully; otherwise, false.</returns>
        public bool Delete()
        {
            return clsData_User.Delete_User_By_ID(this.User_ID);

        }

        static public bool Delete_User(int User_ID)
        {
            return clsData_User.Delete_User_By_ID(User_ID);
        }

        /// <summary>
        /// Retrieves a list of all users in the system.
        /// </summary>
        /// <returns>A DataTable containing the list of users.</returns>
        static public DataTable Get_All_Users()
        {
            return clsData_User.Get_All_Users();
        }

        static public bool Is_User_Exist(int User_ID)
        {
            return clsData_User.Is_User_Exist(User_ID);
        }
        static public bool Is_User_Exist(string UserName)
        {
            return clsData_User.Is_User_Exist(UserName);
        }


        static public DataTable Get_All_Users_Log()
        {
            return clsData_User.Get_All_Users_Log();
        }

        static public DataTable Get_All_Users_Log_By_UserName(string UserName)
        {
            return clsData_User.Get_All_Users_Log_By_UserName(UserName);
        }

        static public bool Add_User_Log(int User_ID, DateTime Login_Date)
        {

            return clsData_User.Add_User_Log(User_ID, Login_Date);
            
        }



    }
}
