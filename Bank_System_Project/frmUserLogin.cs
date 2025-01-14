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

namespace MyBankSystemDesktopApp
{
    public partial class frmUserLogin : Form
    {
        public frmUserLogin()
        {
            InitializeComponent();
        }
        public int Trials = 3;
        private void _Disable_System()
        {
            txtPassword.Enabled = false;
            txtUserName.Enabled = false;
            btnLogin.Enabled = false;

        }

        private void _Login()
        {
            // check if text boxes are filled
            if(txtUserName.Text == String.Empty || txtPassword.Text == String.Empty)
            {
                MessageBox.Show("UserName OR Password Cannot be empty","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

            // check login
            

            if(Trials != 0)
            {
                // first check rapidly by simple function without retrieving all data from database
                if (clsUser.Is_User_Exist(txtUserName.Text))
                {
                    // if found then retrieve all data
                    clsUser user = clsUser.Find(txtUserName.Text);
                    

                    if (user != null)
                    {
                        if (user.Password == txtPassword.Text)
                        {
                            clsGlobal.GlobalUser = user;
                            timer1.Stop();
                            this.Close();

                            // Add Login to User_Log then open Main Screen
                            clsUser.Add_User_Log(clsGlobal.GlobalUser.User_ID,DateTime.Now);
                            frmMainScreen frm = new frmMainScreen();
                            frm.Show();
                        }
                        else
                        {
                            lblLoginFailed.Visible = true;
                            lblLoginFailed.Text = "Invalid UserName/Password,  " + (Trials -1) + " trial(s) left";
                            Trials--;
                        }

                    }
                }
                else
                {
                    lblLoginFailed.Visible = true;
                    lblLoginFailed.Text = "Invalid UserName/Password,  " + (Trials-1) + " trial(s) left";
                    Trials--;
                }
            }

            // case login failed 3 times
            if (Trials == 0)
            {
                MessageBox.Show("Login Failed 3 Times , System Locked please contact you admin", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                _Disable_System();
            }
            

        }

        private void frmUserLogin_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("D") + "\n"+ DateTime.Now.ToString("T");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _Login();
        }
    }
}
