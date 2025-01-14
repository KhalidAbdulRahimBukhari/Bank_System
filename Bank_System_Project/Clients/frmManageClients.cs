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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MyBankSystemDesktopApp
{
    public partial class frmManageClients : Form
    {
        public frmManageClients()
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
            PanelManipulateClients.Controls.Clear();
            PanelManipulateClients.Controls.Add(AccessDenied);
            AccessDenied.Show();
        }

        private void btnShowClients_Click(object sender, EventArgs e)
        {
            if(!clsGlobal.CheckAccess(clsGlobal.ePermissions.pShowClients))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmshowClients ShowClients = new frmshowClients() { TopLevel = false, TopMost = true };
            PanelManipulateClients.Controls.Clear();
            PanelManipulateClients.Controls.Add(ShowClients);
            ShowClients.Show();

            pColour.BackColor = Color.FromArgb(33, 121, 184);
            lblOperation.Text = "Show Clients";
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pAddClient))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmAddClient AddClient = new frmAddClient() { TopLevel = false, TopMost = true };
            PanelManipulateClients.Controls.Clear();
            PanelManipulateClients.Controls.Add(AddClient);
            AddClient.Show();


            pColour.BackColor = Color.CadetBlue;
            lblOperation.Text = "Add Client";
        }

        private void btnEditClient_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pUpdateClient))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmUpdateClient EditClient = new frmUpdateClient() { TopLevel = false, TopMost = true };
            PanelManipulateClients.Controls.Clear();
            PanelManipulateClients.Controls.Add(EditClient);
            EditClient.Show();

            pColour.BackColor = Color.FromArgb(12, 34, 47);
            lblOperation.Text = "Update Client";

        }

        private void btnDeleteClient_Click(object sender, EventArgs e)
        {
            if (!clsGlobal.CheckAccess(clsGlobal.ePermissions.pDeleteClient))
            {
                ShowAccessDeniedForm();
                return;
            }
            frmDeleteClient DeleteClient = new frmDeleteClient() { TopLevel = false, TopMost = true };
            PanelManipulateClients.Controls.Clear();
            PanelManipulateClients.Controls.Add(DeleteClient);
            DeleteClient.Show();

            pColour.BackColor = Color.DarkRed;
            lblOperation.Text = "Delete Client";

        }

        private void frmManageClients_Load(object sender, EventArgs e)
        {
            btnShowClients.PerformClick();
            _Load_UserName_And_Run_Time();
        }
       
        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = clsGlobal.GlobalDate;
        }
    }
}