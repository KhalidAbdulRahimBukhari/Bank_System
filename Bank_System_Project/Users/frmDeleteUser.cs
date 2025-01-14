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
    public partial class frmDeleteUser : Form
    {
        public frmDeleteUser()
        {
            InitializeComponent();
        }

        public enum ePermissions
        {
            pShowUsers = 2, pAddUser = 4, pUpdateUser = 8, pDeleteUser = 16, pUsersLog = 32,
            pShowClients = 64, pAddClient = 128, pUpdateClient = 256, pDeleteClient = 512, pAll = -1
        };

        clsUser currentuser = new clsUser();

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
        private void _Load_Data_To_cbUserName()
        {
            DataView dv = clsUser.Get_All_Users().DefaultView;

            cbUserName.Items.Clear();

            foreach (DataRow dr in dv.Table.Rows)
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
        private void _Load_Data_To_CheckBoxes()
        {
            if (currentuser.Permissions == (int)ePermissions.pAll)
            {
                _Check_All_CheckBoxes();
                return;
            }


            if ((currentuser.Permissions & (int)ePermissions.pShowUsers) == (int)ePermissions.pShowUsers)
                cbShowUsers.Checked = true;
            else
                cbShowUsers.Checked = false;


            if ((currentuser.Permissions & (int)ePermissions.pAddUser) == (int)ePermissions.pAddUser)
                cbAddUser.Checked = true;
            else
                cbAddUser.Checked = false;


            if ((currentuser.Permissions & (int)ePermissions.pUpdateUser) == (int)ePermissions.pUpdateUser)
                cbUpdateUser.Checked = true;
            else
                cbUpdateUser.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pDeleteUser) == (int)ePermissions.pDeleteUser)
                cbDeleteUser.Checked = true;
            else
                cbDeleteUser.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pUsersLog) == (int)ePermissions.pUsersLog)
                cbUsersLog.Checked = true;
            else
                cbUsersLog.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pShowClients) == (int)ePermissions.pShowClients)
                cbShowClients.Checked = true;
            else
                cbShowClients.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pAddClient) == (int)ePermissions.pAddClient)
                cbAddClient.Checked = true;
            else
                cbAddClient.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pUpdateClient) == (int)ePermissions.pUpdateClient)
                cbUpdateclient.Checked = true;
            else
                cbUpdateclient.Checked = false;

            if ((currentuser.Permissions & (int)ePermissions.pDeleteClient) == (int)ePermissions.pDeleteClient)
                cbDeleteClient.Checked = true;
            else
                cbDeleteClient.Checked = false;

        }

        private void _Delete()
        {
            if (MessageBox.Show("Are you sure you want to Delete User " + currentuser.UserName + " ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                

                if (currentuser.Delete())
                {
                    MessageBox.Show("Client Deleted Successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _Load_Data_To_cbUserName();
                }
                else
                {
                    MessageBox.Show("Error : Client is NOT Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            else
            {
                return;
            }
        }

        // ----------------functions up , events + buttons down -----------------------------
        private void frmDeleteUser_Load(object sender, EventArgs e)
        {
            _Load_Data_To_cbUserName();
            _Load_Data_To_TextBoxes();
            _Load_Data_To_CheckBoxes();
        }

        private void cbUserName_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes();
            _Load_Data_To_CheckBoxes();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            _Delete();
        }
    }
}
