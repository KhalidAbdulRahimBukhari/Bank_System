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
    public partial class frmUsersLog : Form
    {
        public frmUsersLog()
        {
            InitializeComponent();
        }


        private void _Load_Data_To_ListView()
        {
            DataView dv = new DataView();

            dv = clsUser.Get_All_Users_Log().DefaultView;

          
            
                foreach (DataRow dr in dv.Table.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["UserName"].ToString());

                    item.SubItems.Add(dr["Login_Date"].ToString());
                    item.SubItems.Add(dr["Password"].ToString());
                    item.SubItems.Add(dr["Permissions"].ToString());

                    lvUsersLoginList.Items.Add(item);

                }

           

        }

        private void _Search_In_ListView()
        {
            if(clsUser.Is_User_Exist(txt_Search.Text))
            {
                DataView dv = clsUser.Get_All_Users_Log_By_UserName(txt_Search.Text).DefaultView;
                lvUsersLoginList.Items.Clear();

                foreach (DataRow dr in dv.Table.Rows)
                {
                    ListViewItem item = new ListViewItem(dr["UserName"].ToString());

                    item.SubItems.Add(dr["Login_Date"].ToString());
                    item.SubItems.Add(dr["Password"].ToString());
                    item.SubItems.Add(dr["Permissions"].ToString());

                    lvUsersLoginList.Items.Add(item);
                }

            }
            else
            {
                lvUsersLoginList.Items.Clear();
                _Load_Data_To_ListView();
            }

        }


        //====================================== Functions up , buttons + events down ---------------------------
        private void frmUsersLog_Load(object sender, EventArgs e)
        {
            _Load_Data_To_ListView();
        }

        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            lvUsersLoginList.Sorting = SortOrder.Ascending;
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            lvUsersLoginList.Sorting = SortOrder.Descending;
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = String.Empty;
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            _Search_In_ListView();
        }
    }
}
