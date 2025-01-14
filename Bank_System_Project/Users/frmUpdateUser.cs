using Bank_Business_Layer;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class frmUpdateUser : Form
    {
        public frmUpdateUser()
        {
            InitializeComponent();
        }
       

        clsUser currentuser = new clsUser();

        private bool _Is_TextBoxes_Empty()
        {
           

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

        private void _Load_Data_To_cbUserName()
        {
            DataView dv = clsUser.Get_All_Users().DefaultView;

            foreach(DataRow dr in dv.Table.Rows)
            {
                cbUserName.Items.Add(dr["UserName"]);
            }

            cbUserName.SelectedIndex = 0;
        }

        private void _Load_Data_To_TextBoxes()
        {
            if (cbUserName.SelectedItem != null)
            {
                currentuser = clsUser.Find(cbUserName.SelectedItem.ToString());

                if (currentuser != null)
                {
                    _Fill_TextBoxes_Tesxts();
                }
            }
        }

        private void _Update_CurrentClient_Info()
        {
            // Update CurrentClients object and Prepare it to save() fun in bussiness layer
            currentuser.FirstName = txtFirstName.Text;
            currentuser.LastName = txtLastName.Text;
            currentuser.Password = txtPassword.Text;
            currentuser.Email = txtEmail.Text;
            currentuser.Phone = txtPhoneNumber.Text;
            currentuser.country = txtCountry.Text;
            currentuser.City = txtCity.Text;
            currentuser.Street = txtStreet.Text;

            // update permissions
            _Update_Permissions();
        }

        private void _Fill_TextBoxes_Tesxts()
        {
            txtFirstName.Text = currentuser.FirstName;
            txtLastName.Text = currentuser.LastName;
            txtPassword.Text = currentuser.Password;
            txtEmail.Text = currentuser.Email;
            txtPhoneNumber.Text = currentuser.Phone;
            txtCountry.Text = currentuser.country;
            txtCity.Text = currentuser.City;
            txtStreet.Text = currentuser.Street;
        }

        private void _Load_Data_To_CheckBoxes()
        {
            if(currentuser.Permissions == (int)clsGlobal.ePermissions.pAll)
            {
                _Check_All_CheckBoxes();
                return;
            }


            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pShowUsers) == (int)clsGlobal.ePermissions.pShowUsers)
                cbShowUsers.Checked = true;
            else
                cbShowUsers.Checked = false;


            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pAddUser) == (int)clsGlobal.ePermissions.pAddUser)
                cbAddUser.Checked = true;
            else
                cbAddUser.Checked = false;


            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pUpdateUser) == (int)clsGlobal.ePermissions.pUpdateUser)
                cbUpdateUser.Checked = true;
            else
                cbUpdateUser.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pDeleteUser) == (int)clsGlobal.ePermissions.pDeleteUser)
                cbDeleteUser.Checked = true;
            else
                cbDeleteUser.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pUsersLog) == (int)clsGlobal.ePermissions.pUsersLog)
                cbUsersLog.Checked = true;
            else
                cbUsersLog.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pShowClients) == (int)clsGlobal.ePermissions.pShowClients)
                cbShowClients.Checked = true;
            else
                cbShowClients.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pAddClient) == (int)clsGlobal.ePermissions.pAddClient)
                cbAddClient.Checked = true;
            else
                cbAddClient.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pUpdateClient) == (int)clsGlobal.ePermissions.pUpdateClient)
                cbUpdateclient.Checked = true;
            else
                cbUpdateclient.Checked = false;

            if ((currentuser.Permissions & (int)clsGlobal.ePermissions.pDeleteClient) == (int)clsGlobal.ePermissions.pDeleteClient)
                cbDeleteClient.Checked = true;
            else
                cbDeleteClient.Checked = false;

        }

        private void _Save()
        {
            if (_Is_TextBoxes_Empty() || _Is_CheckBoxes_Not_Checked())
            {
                MessageBox.Show("Please fill All Text Boxes and 1 CheckBox at least", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save changes to User " + currentuser.UserName + " ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                _Update_CurrentClient_Info();

                if (currentuser.Save())
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

        // -------------functions up , Events + buttons down
        private void frmEditUser_Load(object sender, EventArgs e)
        {
            _Load_Data_To_cbUserName();
            _Load_Data_To_TextBoxes();
            _Load_Data_To_CheckBoxes();
        }

        private void cbFullAccess_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFullAccess.Checked)
                _Check_All_CheckBoxes();
            else
                _Uncheck_All_CheckBoxes();
        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            _Save();
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes();
            _Load_Data_To_CheckBoxes();
        }
    }
}
