using System;
using System.Windows.Forms;
using MainLib.DBServices;
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
                if (this.cbLogin.SelectedValue == null)
                    return;

                if (Auth.WasAuthenticated(this.cbLogin.SelectedValue.ToString(), txtPassword.Text))
                {
                    isLoggedIn = true;
                    Session.CreateSessionInstance(this.cbLogin.SelectedValue.ToString());
                    this.Close();
                }
                else
                    tsslInfo.Text = "Неверное имя пользователя или пароль";
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
        private void LoginForm_Load(object sender, EventArgs e)
        {
            //NOTE: test
            try
            {
                DataSetInitializer.ComboBoxDataSetInitializer<UserFullInfo>(ref cbLogin, DataService.SelectUsersFullInfo(), "login", "ShortName");
            }
            catch (Auth.QueryResultIsNullException)
            {
                tsslInfo.Text = "В базе данных нет информации об пользователях.";
            }
            catch (Auth.DataBaseConnetionException dbEx)
            {
                logger.Error(dbEx);
                MessageBox.Show("Не удается подкючиться к базе данных.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Необработанная ошибка", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
