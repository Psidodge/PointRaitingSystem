#define LOGINLESS
#undef LOGINLESS
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
                Application.Run(new MainForm());
            else
                Application.Exit();
#endif
        }
    }
}
