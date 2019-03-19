//#define LOGINLESS
//#define USR
//#define ADM
using MainLib.Session;
using System;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

//#if LOGINLESS
//#if ADM
//            Session.CreateSessionInstance("admin");
//            Application.Run(new admMainForm());
//#elif USR
//            Session.CreateSessionInstance("cep.sa");
//            Application.Run(new usrMainForm());
//#endif
//#else
            //Login form runs first
            LoginForm loginForm = new LoginForm();
            Application.Run(loginForm);
            if (loginForm.IsLoggedIn)
                if(Session.GetCurrentSession().isAdmin)
                    Application.Run(new admMainForm());
                else
                    Application.Run(new usrMainForm());
            else
                Application.Exit();
//#endif
        }
    }
}
