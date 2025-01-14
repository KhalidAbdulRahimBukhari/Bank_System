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

namespace MyBankSystemDesktopApp.Clients
{
    public partial class frmshowClients : Form
    {
        public frmshowClients()
        {
            InitializeComponent();
        }
        private void frmShowClients_Load(object sender, EventArgs e)
        {
            Fill_ListView_Clients();
        }


        private void Fill_ListView_Clients()
        {
            DataView dv = clsClient.Get_All_Clients().DefaultView;

            ListViewItem item = new ListViewItem();
            foreach (DataRow dr in dv.Table.Rows)
            {
                item = new ListViewItem(dr["AccountNumber"].ToString());


                item.SubItems.Add(dr["PinCode"].ToString());
                item.SubItems.Add(dr["Balance"].ToString());
                item.SubItems.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Phone"].ToString());
                item.SubItems.Add(dr["Country"].ToString());

                lvShowClients.Items.Add(item);
            }
        }


        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            lvShowClients.Sorting = SortOrder.Ascending;
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            lvShowClients.Sorting = SortOrder.Descending;
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            clsClient Client = clsClient.Find(txt_Search.Text);

            if (Client != null)
            {
                lvShowClients.Items.Clear();
                ListViewItem item = new ListViewItem(Client.AccountNumber.ToString());

                item.SubItems.Add(Client.PinCode.ToString());
                item.SubItems.Add(Client.Balance.ToString());
                item.SubItems.Add(Client.FirstName.ToString() + " " + Client.LastName.ToString());
                item.SubItems.Add(Client.Email.ToString());
                item.SubItems.Add(Client.Phone.ToString());
                item.SubItems.Add(Client.country.ToString());

                lvShowClients.Items.Add(item);
            }
            else
            {
                lvShowClients.Items.Clear();
                Fill_ListView_Clients();
            }


        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = string.Empty;
        }

        private void lvShowClients_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
