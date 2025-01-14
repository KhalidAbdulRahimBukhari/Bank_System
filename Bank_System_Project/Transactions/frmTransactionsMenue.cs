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

namespace MyBankSystemDesktopApp.Transactions
{
    public partial class frmTransactionsMenue : Form
    {
        public frmTransactionsMenue()
        {
            InitializeComponent();
        }
        private void _Load_UserName_And_Run_Time()
        {
            lblUserName.Text = clsGlobal.GlobalUser.UserName;
            timer1.Enabled = true;
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
        frmDeposit Deposit = new frmDeposit() { TopLevel = false, TopMost = true };
            PanelManipulateTransactions.Controls.Clear();
            PanelManipulateTransactions.Controls.Add(Deposit);
            Deposit.Show();
        }

        private void btnWithdrawl_Click(object sender, EventArgs e)
        {
        frmWithdraw Withdraw = new frmWithdraw() { TopLevel = false, TopMost = true };
            PanelManipulateTransactions.Controls.Clear();
            PanelManipulateTransactions.Controls.Add(Withdraw);
            Withdraw.Show();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
        frmTransfer Transfer = new frmTransfer() { TopLevel = false, TopMost = true };
            PanelManipulateTransactions.Controls.Clear();
            PanelManipulateTransactions.Controls.Add(Transfer);
            Transfer.Show();
        }

        private void btnTransfersLog_Click(object sender, EventArgs e)
        {
        frmTransfersLog TransfersLog = new frmTransfersLog() { TopLevel = false, TopMost = true };
            PanelManipulateTransactions.Controls.Clear();
            PanelManipulateTransactions.Controls.Add(TransfersLog);
            TransfersLog.Show();
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTransactionsMenue_Load(object sender, EventArgs e)
        {
            btnDeposit.PerformClick();
            _Load_UserName_And_Run_Time();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = clsGlobal.GlobalDate;
        }
    }
}
