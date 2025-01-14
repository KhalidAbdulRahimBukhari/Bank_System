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

namespace MyBankSystemDesktopApp
{
    public partial class frmUpdateClient : Form
    {
        public frmUpdateClient()
        {
            InitializeComponent();
        }

        public clsClient CurrentClient = new clsClient();

        private bool _Is_TextBoxes_Empty()
        {
            if (txtFirstName.Text == String.Empty)
                return true;

            if (txtLastName.Text == String.Empty)
                return true;

            if (txtPinCode.Text == String.Empty)
                return true;

            if (txtEmail.Text == String.Empty)
                return true;

            if (txtPhoneNumber.Text == String.Empty)
                return true;

            if (txtCountry.Text == String.Empty)
                return true;

            if (txtCity.Text == String.Empty)
                return true;

            if (txtStreet.Text == String.Empty)
                return true;

            return false;

        }

        private void _Load_AccountNumbers_To_CbAccountNumber()
        {
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

        private void _Update_CurrentClient_Info()
        {
            // Update CurrentClients object and Prepare it to save() fun in bussiness layer
            CurrentClient.FirstName = txtFirstName.Text;
            CurrentClient.LastName = txtLastName.Text;
            CurrentClient.PinCode = txtPinCode.Text;
            CurrentClient.Email = txtEmail.Text;
            CurrentClient.Phone = txtPhoneNumber.Text;
            CurrentClient.country = txtCountry.Text;
            CurrentClient.City = txtCity.Text;
            CurrentClient.Street = txtStreet.Text;
        }

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

        private void _Save()
        {
            if (_Is_TextBoxes_Empty())
            {
                MessageBox.Show("Please fill All Text Boxes", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save changes to Client " + CurrentClient.AccountNumber + " ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Update_CurrentClient_Info();

                if (CurrentClient.Save())
                {
                    MessageBox.Show("Client Saved Successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error : Client NOT Saved", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                return;
            }
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

        // ------------------------------------- functions up , buttons down

        private void frmEditClient_Load(object sender, EventArgs e)
        {
              _Load_AccountNumbers_To_CbAccountNumber();
              _Load_Data_To_TextBoxes();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void cbAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes();
        }

        private void txt_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;

            if (string.IsNullOrWhiteSpace(txt.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txt, "Text Can`t be Empty");
                txt.Focus();
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txt, "");
            }
        }
    }
}
