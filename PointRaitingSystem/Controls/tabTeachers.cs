using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Cryptography;

namespace PointRaitingSystem
{
    //NOTE: Как либо реализовать создание без автаризационной информации
    //      Авт. информации создавать и привязывать отдельно
    //UNDONE: Смотри выше, работает не так, лучше спросить у заказчика
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
                List<TeacherInfo> teacherInfos = DataService.SelectAllTeachersInfo();
                DataSetInitializer<TeacherInfo>.dgvDataSetInitializer(ref dgvTeachers, teacherInfos, new int[] { 1, 5 }, new string[] { "Name" });
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

        private void tabTeachers_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }

        private void dgvTeachers_SelectionChanged(object sender, EventArgs e)
        {
            //NOTE: dont catch exceptions here
            txtId.Text = dgvTeachers.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvTeachers.CurrentRow.Cells["name"].Value.ToString();
            txtLogin.Text = dgvTeachers.CurrentRow.Cells["login"].Value.ToString();
            txtAuthID.Text = dgvTeachers.CurrentRow.Cells["id_of_authInfo"].Value.ToString();
            checkBoxIsAdmin.Checked = (bool)dgvTeachers.CurrentRow.Cells["isAdmin"].Value;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                //NOTE: check filling
                if ((!loginValdiationComplete && txtLogin.TextLength != 0) || (!passValidationComplete && txtPass.TextLength != 0))
                    return;

                byte[] salt;

                //NOTE: check for filling next filds: txtName
                TeacherInfo userInfo = new TeacherInfo
                {
                    Name = txtName.Text,
                    isAdmin = checkBoxIsAdmin.Checked
                };

                AuthInfoAdmin authInfo = new AuthInfoAdmin
                {
                    login = txtLogin.Text,
                    Pass_hash = PasswordEncryptor.GetHashedPassword(txtPass.Text, out salt),
                    Salt = salt
                };

                int recAffected = DataService.InsertIntoTeachersTable(userInfo, authInfo);

                if (recAffected > 0)
                {
                    //NOTE: добавить пометку новых записей
                    InitializeDataSets();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                TeacherInfo userInfo = new TeacherInfo
                {
                    id = (int)dgvTeachers.CurrentRow.Cells["id"].Value,
                    Name = txtName.Text,
                    isAdmin = checkBoxIsAdmin.Checked,
                    id_of_authInfo = (int)dgvTeachers.CurrentRow.Cells["id_of_authInfo"].Value
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
        //NOTE: mapper here
        private void btnLoadFromEXCEL_Click(object sender, EventArgs e)
        {

        }


        private void txtLogin_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex = new Regex("^(?=.{5,25}$)(?![_.])(?!.*[_.]{2})[a-zA-Z0-9._]+(?<![_.])$");
           
            if (regex.IsMatch(txtLogin.Text) && !DataService.CheckLogin(txtLogin.Text))
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
        private void txtPass_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,15}$");

            if (regex.IsMatch(txtPass.Text) && loginValdiationComplete)
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
