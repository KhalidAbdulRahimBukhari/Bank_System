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
    public partial class frmShowUsers : Form
    {
        public frmShowUsers()
        {
            InitializeComponent();
        }
        private void _Fill_ListView_Users()
        {
            DataView dv = clsUser.Get_All_Users().DefaultView;


            foreach (DataRow dr in dv.Table.Rows)
            {
                ListViewItem item = new ListViewItem(dr["UserName"].ToString());

                item.SubItems.Add(dr["Password"].ToString());
                item.SubItems.Add(dr["Permissions"].ToString());
                item.SubItems.Add(dr["FirstName"].ToString() + " " + dr["LastName"].ToString());
                item.SubItems.Add(dr["Email"].ToString());
                item.SubItems.Add(dr["Phone"].ToString());
                item.SubItems.Add(dr["Country"].ToString());

                lvShowUsers.Items.Add(item);

            }

        }

        private void _Text_Changed()
        {
            clsUser user = clsUser.Find(txt_Search.Text.ToString());

            if (user != null)
            {
                lvShowUsers.Items.Clear();
                ListViewItem item = new ListViewItem(user.UserName.ToString());

                item.SubItems.Add(user.Password.ToString());
                item.SubItems.Add(user.Permissions.ToString());
                item.SubItems.Add(user.FirstName.ToString() + " " + user.LastName.ToString());
                item.SubItems.Add(user.Email.ToString());
                item.SubItems.Add(user.Phone.ToString());
                item.SubItems.Add(user.country.ToString());

                lvShowUsers.Items.Add(item);

            }
            else
            {
                lvShowUsers.Items.Clear();
                _Fill_ListView_Users();
            }
        }


        //-------------------------  Functions up , events + buttons down ------------------------------
        private void rbASC_CheckedChanged(object sender, EventArgs e)
        {
            lvShowUsers.Sorting = SortOrder.Ascending;
        }

        private void rbDESC_CheckedChanged(object sender, EventArgs e)
        {
            lvShowUsers.Sorting = SortOrder.Descending;
        }

        private void txt_Search_TextChanged(object sender, EventArgs e)
        {
            _Text_Changed();
        }

        private void txt_Search_Click(object sender, EventArgs e)
        {
            txt_Search.Text = String.Empty;
        }

        private void frmShowUsers_Load(object sender, EventArgs e)
        {
            _Fill_ListView_Users();
        }
    }
}
