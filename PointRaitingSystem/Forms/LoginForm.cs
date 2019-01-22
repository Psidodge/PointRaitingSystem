using System;
using System.Windows.Forms;
using MainLib.Auth;
using MainLib.Session;

namespace PointRaitingSystem
{
    public partial class LoginForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool isLoggedIn = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
        }

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
                MessageBox.Show("Успешно перестало работать", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public bool IsLoggedIn { get => isLoggedIn; }
    }
}
