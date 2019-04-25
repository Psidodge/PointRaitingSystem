using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Hashing;

namespace PointRaitingSystem
{
    public partial class tabTeachers : UserControl
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool loginValdiationComplete = false,
                     passValidationComplete = false;

        private void Clear()
        {
            txtAuthID.Clear();
            txtId.Clear();
            txtLogin.Clear();
            txtName.Clear();
            txtPass.Clear();
        }
        private void InitializeDataSets()
        {
            Clear();
            try
            {
                List<UserInfo> teacherInfos = DataService.SelectAllUsers();
                DataSetInitializer.dgvDataSetInitializer<UserInfo>(ref dgvTeachers, teacherInfos, new int[] { 0, 3 }, new string[] { "Name" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }


        public tabTeachers()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            InitializeDataSets();
        }

        private void tabTeachers_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }
        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTeachers.CurrentRow == null)
                return;

            //NOTE: dont catch exceptions here
            lblInfo.Text = string.Empty;

            txtId.Text = dgvTeachers.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvTeachers.CurrentRow.Cells["name"].Value.ToString();
            checkBoxIsAdmin.Checked = (bool)dgvTeachers.CurrentRow.Cells["isAdmin"].Value;

            AuthInfoAdmin auth = null;

            try
            {
                auth = DataService.SelectAuthInfoByUserID(uint.Parse(txtId.Text));
            }
            catch (Exception)
            {
                lblInfo.Text = "Данные авторизации отсутствуют";
                txtLogin.Text = string.Empty;
                txtAuthID.Text = string.Empty;
                return;
            }

            txtLogin.Text = auth.login;
            txtAuthID.Text = auth.id.ToString();
        }
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo userInfo = new UserInfo
                {
                    Name = txtName.Text,
                    isAdmin = checkBoxIsAdmin.Checked
                };

                uint recordId = DataService.InsertIntoTeachersTable(userInfo);

                if (recordId > 0)
                {
                    InitializeDataSets();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            try
            {
                UserInfo userInfo = new UserInfo
                {
                    id = (uint)dgvTeachers.CurrentRow.Cells["id"].Value,
                    Name = txtName.Text,
                    isAdmin = checkBoxIsAdmin.Checked
                };

                int recAffected = DataService.UpdateTeachers(userInfo);

                if(recAffected > 0)
                {
                    InitializeDataSets();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        

        private void btnUpdateAuth_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text) && loginValdiationComplete)
            {
                lblInfo.Text = "Данные не прошли валидацию.";
                return;
            }

            byte[] genSalt;

            AuthInfoAdmin auth = new AuthInfoAdmin()
            {
                id = uint.Parse(txtAuthID.Text),
                hash = PasswordHashing.GetHashedPassword(txtPass.Text, out genSalt),
                salt = genSalt
            };

            try
            {
                if(DataService.UpdateAuthInfo(auth) > 0)
                    lblInfo.Text = "Данные успешно изменены.";
            }
            catch(Exception ex)
            {
                lblInfo.Text = string.Format("Произошла ошибка.{0}Запись не изменена.", Environment.NewLine);
                logger.Error(ex);
            }
        }

        private void btnAddAuth_Click(object sender, EventArgs e)
        {
            if(passValidationComplete && loginValdiationComplete)
            {
                lblInfo.Text = "Данные не прошли валидацию.";
                return;
            }

            byte[] genSalt;

            AuthInfoAdmin auth = new AuthInfoAdmin()
            {
                login = txtLogin.Text,
                hash = PasswordHashing.GetHashedPassword(txtPass.Text, out genSalt),
                salt = genSalt
            };

            try
            {
                UserInfo userInfo = new UserInfo
                {
                    id      =   uint.Parse(txtId.Text),
                    Name    =   txtName.Text,
                    isAdmin =   checkBoxIsAdmin.Checked,
                    authID  =   DataService.InsertIntoAuthInfo(auth)
                };

                if(DataService.UpdateTeachers(userInfo) > 0)
                {
                    lblInfo.Text = "Данные сохранены.";
                }
            }
            catch (Exception ex)
            {
                lblInfo.Text = string.Format("Произошла ошибка.{0}Запись не сохранена.", Environment.NewLine);
                logger.Error(ex);
            }
        }

        private void txtLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex = new Regex("^(?=.{5,25}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");

            if (regex.IsMatch(txtLogin.Text) && !DataService.isLoginExist(txtLogin.Text))
            {
                txtLogin.ForeColor = Color.Green;
                loginValdiationComplete = true;
            }
            else
            {
                txtLogin.ForeColor = Color.Red;
                loginValdiationComplete = false;
            }
        }

        private void dgvTeachers_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        private void txtPass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)");//.{5,15}$

            if (regex.IsMatch(txtPass.Text))
            {
                txtPass.ForeColor = Color.Green;
                passValidationComplete = true;
            }
            else
            {
                txtPass.ForeColor = Color.Red;
                passValidationComplete = false;
            }
        }
    }
}
