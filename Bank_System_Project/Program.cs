using MyBankSystemDesktopApp.Clients;
using MyBankSystemDesktopApp.Transactions;
using MyBankSystemDesktopApp.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyBankSystemDesktopApp
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frmUserLogin frm = new frmUserLogin();
            frm.Show();
            Application.Run();
        }
    }
}
