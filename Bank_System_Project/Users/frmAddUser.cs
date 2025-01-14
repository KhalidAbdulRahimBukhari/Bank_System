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

namespace MyBankSystemDesktopApp.Users
{
    public partial class frmAddUser : Form
    {
        public frmAddUser()
        {
            InitializeComponent();
        }
      
        clsUser currentuser = new clsUser();




        private void _Clear_Text_Boxes()
        {
            txtUserName.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPassword.Clear();
            txtEmail.Clear();
            txtPhoneNumber.Clear();
            txtCountry.Clear();
            txtCity.Clear();
            txtStreet.Clear();

        }

        private bool _Is_TextBoxes_Empty()
        {
            if (txtUserName.Text == String.Empty)
                return true;

            if (txtFirstName.Text == String.Empty)
                return true;

            if (txtLastName.Text == String.Empty)
                return true;

            if (txtPassword.Text == String.Empty)
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

        private bool _Is_CheckBoxes_Not_Checked()
        {
            if (
                cbShowClients.Checked == false &&
                cbAddClient.Checked == false &&
                cbUpdateclient.Checked == false &&
                cbDeleteClient.Checked == false &&
                cbShowUsers.Checked == false &&
                cbAddUser.Checked == false &&
                cbUpdateUser.Checked == false &&
                cbDeleteUser.Checked == false &&
                cbUsersLog.Checked == false
              )
                return true;
            else
                return false;
        }

        private bool _Is_All_CheckBoxes_Checked()
        {
            if (
                cbShowClients.Checked == true &&
                cbAddClient.Checked == true &&
                cbUpdateclient.Checked == true &&
                cbDeleteClient.Checked == true &&
                cbShowUsers.Checked == true &&
                cbAddUser.Checked == true &&
                cbUpdateUser.Checked == true &&
                cbDeleteUser.Checked == true &&
                cbUsersLog.Checked == true
              )
                return true;
            else
                return false;
        }

        private void _Update_CurrentUser_Info()
        {
            // Update CurrentClients object and Prepare it to save() fun in bussiness layer
            currentuser.UserName = txtUserName.Text;
            currentuser.FirstName = txtFirstName.Text;
            currentuser.LastName = txtLastName.Text;
            currentuser.Password = txtPassword.Text;
            currentuser.Email = txtEmail.Text;
            currentuser.Phone = txtPhoneNumber.Text;
            currentuser.country = txtCountry.Text;
            currentuser.City = txtCity.Text;
            currentuser.Street = txtStreet.Text;
        }
        private void _Add_New_User()
        {
            if (_Is_TextBoxes_Empty() || _Is_CheckBoxes_Not_Checked())
            {
                MessageBox.Show("Please fill All Text Boxes and 1 CheckBox at least", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(clsUser.Is_User_Exist(txtUserName.Text))
            {
                MessageBox.Show("Client with Username : " + txtUserName.Text + " Alreadt Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to add User ?"+ currentuser.UserName , "Validation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                _Update_CurrentUser_Info();

                if (currentuser.Save())
                {
                    MessageBox.Show("User " + currentuser.UserName + " has been saved successfully");
                }
                else
                {
                    MessageBox.Show("Adding new currentuser failed");
                }

            }
            else
            {
                return;
            }

        }


        private void _Update_Permissions()
        {
            // if currentuser has full access we assign -1 to permissions
            if (_Is_All_CheckBoxes_Checked())
            {
                currentuser.Permissions = -1;
                return;
            }


            currentuser.Permissions = 0;

            if (cbShowClients.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pShowClients;

            if (cbAddClient.Checked)
            currentuser.Permissions += (int)clsGlobal.ePermissions.pAddClient;

            if (cbUpdateclient.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pUpdateClient;

            if (cbDeleteClient.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pDeleteClient;

            if (cbShowUsers.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pShowUsers;

            if (cbAddUser.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pAddUser;

            if (cbUpdateUser.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pUpdateUser;

            if (cbDeleteUser.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pDeleteUser;

            if (cbUsersLog.Checked)
                currentuser.Permissions += (int)clsGlobal.ePermissions.pUsersLog;


           
        }

        private void _Check_All_CheckBoxes()
        {
            cbShowClients.Checked = true;
            cbAddClient.Checked = true;
            cbUpdateclient.Checked = true;
            cbDeleteClient.Checked = true;
            cbShowUsers.Checked = true;
            cbAddUser.Checked = true;
            cbUpdateUser.Checked = true;
            cbDeleteUser.Checked = true;
            cbUsersLog.Checked = true;
        }

        private void _Uncheck_All_CheckBoxes()
        {
            cbShowClients.Checked = false;
            cbAddClient.Checked = false;
            cbUpdateclient.Checked = false;
            cbDeleteClient.Checked = false;
            cbShowUsers.Checked = false;
            cbAddUser.Checked = false;
            cbUpdateUser.Checked = false;
            cbDeleteUser.Checked = false;
            cbUsersLog.Checked = false;
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

        private void Check_Box_CheckedChanged(object sender, EventArgs e)
        {
            _Update_Permissions();
        }

        private void cbFullAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFullAccess.Checked)
                _Check_All_CheckBoxes();
            else
                _Uncheck_All_CheckBoxes();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            _Add_New_User();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            _Clear_Text_Boxes();
            _Uncheck_All_CheckBoxes();
        }
    }
}
