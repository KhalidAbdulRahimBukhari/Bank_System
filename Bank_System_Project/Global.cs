using Bank_Business_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBankSystemDesktopApp
{
    public class clsGlobal
    {
        public static clsUser GlobalUser = new clsUser();

        public static string GlobalDate =  DateTime.Now.ToString("D") + "\n"+ DateTime.Now.ToString("T");

        // Enums are types, not variables. Therefore they are 'static' per definition, you don`t need the keyword static
        public enum ePermissions
        {
            pShowUsers = 2, pAddUser = 4, pUpdateUser = 8, pDeleteUser = 16, pUsersLog = 32,
            pShowClients = 64, pAddClient = 128, pUpdateClient = 256, pDeleteClient = 512, pAll = -1
        };


        public static bool CheckAccess(clsGlobal.ePermissions Permission)
        {
            if ((int)clsGlobal.GlobalUser.Permissions == (int)clsGlobal.ePermissions.pAll)
            {
                return true;
            }

            if (((int)clsGlobal.GlobalUser.Permissions & (int)Permission) == (int)Permission)
            {
                return true;
            }

            return false;
        }


        
    }
}
