using Bank_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBankSystemDesktopApp
{
    public partial class frmAddClient : Form
    {
        public frmAddClient()
        {
            InitializeComponent();
        }

        private void _Clear_Text_Boxes()
        {
            txtAccountNumber.Text = "   [????????]";
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPinCode.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtCountry.Clear();
            txtCity.Clear();
            txtStreet.Clear();
        }

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
        private void _Add_New_Client()
        {
            if(_Is_TextBoxes_Empty())
            {
                MessageBox.Show("Please fill All Text Boxes","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            if(MessageBox.Show("Are you sure yo want to add this client ?","Validation",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                clsClient client = new clsClient();

                client.FirstName = txtFirstName.Text;
                client.LastName = txtLastName.Text;
                client.PinCode = txtPinCode.Text;
                client.Email = txtEmail.Text;
                client.Phone = txtPhoneNumber.Text;
                client.country = txtCountry.Text;
                client.City = txtCity.Text;
                client.Street = txtStreet.Text;

                if(client.Save())
                {
                    txtAccountNumber.Text = client.AccountNumber.ToString();
                    MessageBox.Show("Client " + client.AccountNumber + "has been saved successfully");
                }
                else
                {
                    MessageBox.Show("Adding new client failed");
                }

            }
            else
            {
                return;
            }

        }

        //--------------------------------- Functions up , Events + buttons down ---------------------------
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            _Clear_Text_Boxes();
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            _Add_New_Client();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            _Clear_Text_Boxes();
        }
    }
}
