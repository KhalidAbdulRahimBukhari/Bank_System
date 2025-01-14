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
    public partial class frmTransfer : Form
    {
        public frmTransfer()
        {
            InitializeComponent();
        }

        enum eTransactionType { Deposit = 1, Withdrawl = 2, Transfer = 3 };

        public clsClient FromClient = new clsClient();
        public clsClient ToClient = new clsClient();


        private void _Load_Data_To_TextBoxes_From()
        {
            if (cbFromAccountNumber.SelectedItem != null)
            {
                FromClient = clsClient.Find(cbFromAccountNumber.SelectedItem.ToString());

                if (FromClient != null)
                {
                    _Fill_From_TextBoxes_Tesxts();
                }
            }
        }

        private void _Load_Data_To_TextBoxes_To()
        {
            if (cbToAccountNumber.SelectedItem != null)
            {
                ToClient = clsClient.Find(cbToAccountNumber.SelectedItem.ToString());

                if (ToClient != null)
                {
                    _Fill_To_TextBoxes_Tesxts();
                }
            }
        }


        private bool _Add_Transaction_To_DataBase()
        {
            clsTransaction CurrentTransaction = new clsTransaction();
            // first fill data to CurrentTransaction
            CurrentTransaction.Transaction_Type_ID = (int)eTransactionType.Transfer;
            CurrentTransaction.Sender_Acc = Convert.ToInt32(FromClient.AccountNumber);
            CurrentTransaction.Reciver_Acc = Convert.ToInt32(ToClient.AccountNumber);
            CurrentTransaction.Transaction_Date_Time = DateTime.Now;
            CurrentTransaction.User_ID = 1; // Update this later khaled by adding global clsUser user;
            CurrentTransaction.Amount = Convert.ToDouble(txtAmount.Text);

            // Add current Data to DataBase
            return CurrentTransaction.Add();
        }

        private void _Load_AccountNumbers_To_CbAccountNumber()
        {
            // Load Clients from database and add them to ComboBox Items ( Combo box to and from)
            DataTable dt = clsClient.Get_All_Clients();

            foreach (DataRow dr in dt.Rows)
            {
                cbFromAccountNumber.Items.Add(dr["AccountNumber"]);
                cbToAccountNumber.Items.Add(dr["AccountNumber"]);
            }

            // we assign 0 as an index to 'Form' ComboBox and allow search in ComboBox
            cbFromAccountNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbFromAccountNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbFromAccountNumber.SelectedIndex = 0;
            // we assign 0 as an index to 'To' ComboBox and allow search in ComboBox
            cbToAccountNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cbToAccountNumber.AutoCompleteSource = AutoCompleteSource.ListItems;
            cbToAccountNumber.SelectedIndex = 0;
        }

        private void _Fill_From_TextBoxes_Tesxts()
        {
            // fill from text boxes
            txtFirstName.Text = FromClient.FirstName;
            txtLastName.Text = FromClient.LastName;
            txtBalance.Text = FromClient.Balance.ToString();

            
        }
        private void _Fill_To_TextBoxes_Tesxts()
        {
            // fill to text boxes
            txtToFirstName.Text = ToClient.FirstName;
            txtToLastName.Text = ToClient.LastName;
            txtToBalance.Text = ToClient.Balance.ToString();
        }



        private void _Transfer()
        {
            if (txtAmount.Text == String.Empty)
            {
                MessageBox.Show("Please fill Amount TextBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(cbFromAccountNumber.SelectedItem.ToString() == cbToAccountNumber.SelectedItem.ToString())
            {
                MessageBox.Show("You Can`t transfer from and to the same client", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (FromClient.Balance < Convert.ToDouble(txtAmount.Text))
            {
                MessageBox.Show("Withdraw Failed ,withdrawl Amount should not exceed : $" + FromClient.Balance);
                return;
            }


            if (MessageBox.Show("Are you sure you want to Confirm Transaction From Client " + FromClient.AccountNumber + " To Client " + ToClient.AccountNumber + " ?",
                                "Validating", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (_Add_Transaction_To_DataBase())
                {
                    if (clsTransaction.Transfer(FromClient.Client_ID, ToClient.Client_ID, Convert.ToDouble(txtAmount.Text)))
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
        private void frmTransfer_Load(object sender, EventArgs e)
        {
            _Load_AccountNumbers_To_CbAccountNumber();
            _Load_Data_To_TextBoxes_From();
            _Load_Data_To_TextBoxes_To();
        }

        private void cbFromAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes_From();
        }

        private void cbToAccountNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            _Load_Data_To_TextBoxes_To();
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            _Transfer();
            _Load_Data_To_TextBoxes_From();
            _Load_Data_To_TextBoxes_To();
        }
    }
}
