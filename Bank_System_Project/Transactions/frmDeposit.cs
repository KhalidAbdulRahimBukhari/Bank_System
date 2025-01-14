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

namespace MyBankSystemDesktopApp.Transactions
{
    public partial class frmDeposit : Form
    {
        public frmDeposit()
        {
            InitializeComponent();
        }

        enum eTransactionType { Deposit = 1 , Withdrawl =2 , Transfer = 3};

        public clsClient CurrentClient = new clsClient();

        public clsTransaction CurrentTransaction = new clsTransaction();

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

        private bool _Add_Transaction_To_DataBase()
        {
            // first fill data to CurrentTransaction
            CurrentTransaction.Transaction_Type_ID = (int)eTransactionType.Deposit;
            CurrentTransaction.Sender_Acc = null;
            CurrentTransaction.Reciver_Acc = Convert.ToInt32(CurrentClient.AccountNumber);
            CurrentTransaction.Transaction_Date_Time = DateTime.Now;
            CurrentTransaction.User_ID = 1; // Update this later khaled by adding global clsUser user;
            CurrentTransaction.Amount = Convert.ToDouble(txtAmount.Text);

            // Add current Data to DataBase
            return CurrentTransaction.Add();
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

        private void _Fill_TextBoxes_Tesxts()
        {
            txtFirstName.Text = CurrentClient.FirstName;
            txtLastName.Text = CurrentClient.LastName;
            txtBalance.Text = CurrentClient.Balance.ToString();
            
        }

        private void _Deposit()
        {
            if (txtAmount.Text == String.Empty)
            {
                MessageBox.Show("Please fill Amount TextBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to save changes to Client " + CurrentClient.AccountNumber + " Balance ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if(_Add_Transaction_To_DataBase())
                {
                    if (clsTransaction.Deposit(CurrentClient.Client_ID, Convert.ToDouble(txtAmount.Text)))
                    {
                        MessageBox.Show("Balance Updated Successfully", "Done!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error : Client Balance NOT Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                else
                {
                    MessageBox.Show("Error : Client Balance NOT Updated", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                return;
            }
        }

        // ------------------------------------- functions up , buttons down
        private void frmDeposit_Load(object sender, EventArgs e)
        {
            _Load_AccountNumbers_To_CbAccountNumber();
            _Load_Data_To_TextBoxes();
        }

        private void cbAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            _Deposit(); 
            _Load_Data_To_TextBoxes();
        }
    }
}
