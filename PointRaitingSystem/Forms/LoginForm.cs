using System;
using System.Configuration;
using System.Windows.Forms;
using MainLib;

namespace PointRaitingSystem
{
    public partial class LoginForm : Form
    {
        private bool isLoggedIn;
        private SQLworker sqlHandler;
        private PasswordEncrypt passwordEncrypt;

        public LoginForm(ref SQLworker _sqlHandler)
        {
            InitializeComponent();
            this.sqlHandler = _sqlHandler;
            isLoggedIn = false;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            if(!this.sqlHandler.CheckConnection())
            {
                dataSourceConnectionForm form = new dataSourceConnectionForm(ref this.sqlHandler);
                form.ShowDialog();
                if (form.IsCanceld)
                    MessageBox.Show("Подключение к базе данных недоступено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                form.Dispose();
            }
            else
            {
                FillTeacherCBItems();
            }
        }

        private void FillTeacherCBItems()
        {
            this.cbUserName.DataSource = sqlHandler.ExecuteQuery("select Name, id_AuthInfo from Teachers");
            this.cbUserName.ValueMember = "id_AuthInfo";
            this.cbUserName.DisplayMember = "Name";
        }

        private bool AuthCompete()
        {
            System.Data.DataTable dt = sqlHandler.ExecuteQuery(string.Format("select pass_hash from AuthInfo where id = {0}",
                                                                                this.cbUserName.SelectedValue.ToString()));
            if (this.txbPassword.Text == dt.Rows[0].ItemArray[0].ToString())
                return true;
            return false;
        }
        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (!AuthCompete())
                return;
            Application.OpenForms["MainForm"].Visible = true;
            Application.OpenForms["MainForm"].Focus();
            this.isLoggedIn = true;
            this.Close();
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(!isLoggedIn)
            {
                Application.OpenForms["MainForm"].Close();
            }
        }
    }
}
