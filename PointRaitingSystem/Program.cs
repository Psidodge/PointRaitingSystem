#define LOGINLESS
#undef LOGINLESS
using MainLib.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

#if LOGINLESS
            Application.Run(new MainForm("sidor"));
#else
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
#endif
        }
    }
}
