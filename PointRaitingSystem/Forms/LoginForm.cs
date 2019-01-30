using System;
using System.Windows.Forms;
using MainLib.Auth;
using MainLib.Session;

namespace PointRaitingSystem
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool isLoggedIn = false;

        private void btnEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (Auth.WasAuthenticated(txtLogin.Text, txtPassword.Text))
                {
                    isLoggedIn = true;
                    CurrentSession.CreateSessionInstance(this.txtLogin.Text);
                    this.Close();
                }
            }catch(Auth.QueryResultIsNullException)
            {
                //tsslInfoLabel.Text = "Неверное имя пользователя или пароль";
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Необработанная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool IsLoggedIn { get => isLoggedIn; }
    }
}
