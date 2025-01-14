using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank_Business_Layer
{
    public class clsPerson
    {

        public int Person_ID { get; protected set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public string Email { get; set; }   
        public string Phone { get; set; }
        public string country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

       

        protected clsPerson()
        {
            Person_ID = -1;
            FirstName = "";
            LastName = "";
            Email = "";
            Phone = "";
            country = "";
            City = "";
            Street = "";
            
        }


        protected clsPerson(int Person_ID ,string FirstName , string LastName , string Email , string Phone , string Country , string City , string Street)
        {
            this.Person_ID = Person_ID;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Email = Email;
            this.Phone = Phone;
            this.country = Country;
            this.Street  = Street;
            this.City = City;
        }







    }
}
