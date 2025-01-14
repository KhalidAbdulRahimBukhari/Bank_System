using Bank_Business_Layer;
using MyBankSystemDesktopApp.Clients;
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
    public partial class frmManageUsers : Form
    {
        public frmManageUsers()
        {
            InitializeComponent();
        }
        private void _Load_UserName_And_Run_Time()
        {
            lblUserName.Text = clsGlobal.GlobalUser.UserName;
            timer1.Enabled = true;
        }

        public void ShowAccessDeniedForm()
        {
            frmAccessDenied AccessDenied = new frmAccessDenied() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(AccessDenied);
            AccessDenied.Show();
        }


        private void btnShowUsers_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pShowUsers))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmShowUsers ShowUsers = new frmShowUsers() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(ShowUsers);
            ShowUsers.Show();

            // manipulate interface
            pColour.BackColor = Color.FromArgb(33, 121, 184);
            lblOperation.Text = "Show Users";
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pAddUser))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmAddUser AddUser = new frmAddUser() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(AddUser);
            AddUser.Show();

            pColour.BackColor = Color.CadetBlue;
            lblOperation.Text = "Add User";

        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pUpdateUser))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmUpdateUser EditUser = new frmUpdateUser() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(EditUser);
            EditUser.Show();

            pColour.BackColor = Color.FromArgb(12, 34, 47);
            lblOperation.Text = "Update User";

        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pDeleteUser))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmDeleteUser DeleteUser = new frmDeleteUser() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(DeleteUser);
            DeleteUser.Show();

            pColour.BackColor = Color.DarkRed;
            lblOperation.Text = "Delete User";

        }

        private void btnUserLog_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pUsersLog))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmUsersLog UsersLog = new frmUsersLog() { TopLevel = false, TopMost = true };
            PanelManipulateUsers.Controls.Clear();
            PanelManipulateUsers.Controls.Add(UsersLog);
            UsersLog.Show();

            pColour.BackColor = Color.Indigo;
            lblOperation.Text = "Users Login_Log";

        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            btnShowUsers.PerformClick();
            _Load_UserName_And_Run_Time();
        }
    }
}
