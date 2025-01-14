using MyBankSystemDesktopApp.Transactions;
using MyBankSystemDesktopApp.Users;
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
    internal partial class frmMainScreen : Form
    {
        
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void _Load_UserName_And_Run_Time()
        {
            lblUserName.Text = clsGlobal.GlobalUser.UserName;
            timer1.Enabled = true;
        }

        frmManageClients ManageClients = new frmManageClients();
        frmManageUsers ManageUsers = new frmManageUsers();
        frmTransactionsMenue TransactionsMenue = new frmTransactionsMenue();
        frmUserLogin UserLogin = new frmUserLogin();

        private void btnManageClients_Click(object sender, EventArgs e)
        {
            ManageClients.ShowDialog();
        }

        private void btnManageUsers_Click(object sender, EventArgs e)
        {
            ManageUsers.ShowDialog();
        }

   

        private void frmMainScreen_Load(object sender, EventArgs e)
        {
            _Load_UserName_And_Run_Time();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = clsGlobal.GlobalDate;
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            frmUserLogin frm = new frmUserLogin();
            frm.Show();
        }

        private void btnClientsTransactions_Click_1(object sender, EventArgs e)
        {
            TransactionsMenue.ShowDialog();
        }
    }
}
