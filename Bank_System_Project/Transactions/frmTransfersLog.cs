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
    public partial class frmTransfersLog : Form
    {
        public frmTransfersLog()
        {
            InitializeComponent();
        }

        private void _Load_Data_To_ListView()
        {
            DataView dv = new DataView();

            dv = clsTransaction.Get_All_Transactions().DefaultView;

            foreach(DataRow dr in dv.Table.Rows)
            {
                ListViewItem item = new ListViewItem(dr["Date"].ToString());

                item.SubItems.Add(dr["Type_Name"].ToString());
                item.SubItems.Add(dr["Sender_Acc"].ToString());
                item.SubItems.Add(dr["Receiver_Acc"].ToString());
                item.SubItems.Add(dr["UserName"].ToString());

                lvTransactionsList.Items.Add(item);
            }

        }

        private void _Search_By_AccountNumber()
        {
            DataView dv = new DataView();

            if(int.TryParse(txt_Search.Text, out _))
            {
                dv = clsTransaction.List_Transfers_By_Client_AccountNumber(Convert.ToInt32(txt_Search.Text)).DefaultView;
                lvTransactionsList.Items.Clear();

                if (dv.Table.Rows.Count !=0)
                {
                    foreach (DataRow dr in dv.Table.Rows)
                    {
                        ListViewItem item = new ListViewItem(dr["Date"].ToString());

                        item.SubItems.Add(dr["Type_Name"].ToString());
                        item.SubItems.Add(dr["Sender_Acc"].ToString());
                        item.SubItems.Add(dr["Receiver_Acc"].ToString());
                        item.SubItems.Add(dr["UserName"].ToString());

                        lvTransactionsList.Items.Add(item);
                    }
                }
                else
                {
                    lvTransactionsList.Items.Clear();
                    _Load_Data_To_ListView();
                }
            }
            

          
        }

        private void frmTransfersLog_Load(object sender, EventArgs e)
        {
            _Load_Data_To_ListView();
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            _Search_By_AccountNumber();
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = string.Empty;
        }

        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            lvTransactionsList.Sorting = SortOrder.Ascending;
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            lvTransactionsList.Sorting = SortOrder.Descending;
        }
    }
}
