using Bank_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBankSystemDesktopApp.Clients
{
    public partial class frmDeleteClient : Form
    {
        public frmDeleteClient()
        {
            InitializeComponent();
        }

        public clsClient CurrentClient = new clsClient();

        private void _Fill_TextBoxes_Tesxts()
        {
            txtFirstName.Text = CurrentClient.FirstName;
            txtLastName.Text = CurrentClient.LastName;
            txtPinCode.Text = CurrentClient.PinCode;
            txtEmail.Text = CurrentClient.Email;
            txtPhoneNumber.Text = CurrentClient.Phone;
            txtCountry.Text = CurrentClient.country;
            txtCity.Text = CurrentClient.City;
            txtStreet.Text = CurrentClient.Street;
        }


        private void _Load_AccountNumbers_To_CbAccountNumber()
        {
            cbAccountNumber.Items.Clear();

            // Load Clients from database and add them to ComboBox Items
            DataTable dt = clsClient.Get_All_Clients();

            foreach (DataRow dr in dt.Rows)
            {
                cbAccountNumber.Items.Add(dr["AccountNumber"]);
            }

            // we assign 0 as an index to ComboBox and allow search in ComboBox
            cbAccountNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbAccountNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbAccountNumber.SelectedIndex = 0;
        }

        private void _Load_Data_To_TextBoxes()
        {
            if (cbAccountNumber.SelectedItem != null)
            {
                CurrentClient = clsClient.Find(cbAccountNumber.SelectedItem.ToString());

                if (CurrentClient != null)
                {
                    _Fill_TextBoxes_Tesxts();
                }
            }
        }

        private void _Delete_Client()
        {

            if (MessageBox.Show("Are you sure you want to delete client " + CurrentClient.AccountNumber + " ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (CurrentClient.Delete())
                {
                    MessageBox.Show("Client " + CurrentClient.AccountNumber + " Is Deleted Successfully");
                    _Load_AccountNumbers_To_CbAccountNumber();
                    _Load_Data_To_TextBoxes();
                }
                else
                {
                    MessageBox.Show("Client " + CurrentClient.AccountNumber + " Is NOT Deleted");
                }
            }
            else
                return;
        }


        private void frmDeleteClient_Load(object sender, EventArgs e)
        {
            _Load_AccountNumbers_To_CbAccountNumber();
            _Load_Data_To_TextBoxes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            _Delete_Client();            
        }

        private void cbAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes();
        }
    }
}
