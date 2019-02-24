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
                    Session.CreateSessionInstance(this.txtLogin.Text);
                    this.Close();
                }
            }
            catch (Auth.QueryResultIsNullException)
            {
                tsslInfo.Text = "Неверное имя пользователя или пароль";
            }
            catch(Auth.DataBaseConnetionException dbEx)
            {
                logger.Error(dbEx);
                MessageBox.Show("Не удается подкючиться к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
                btnEnter_Click(this, e);
        }
    }
}
