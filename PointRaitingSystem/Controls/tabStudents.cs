using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    public partial class tabStudents : UserControl
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        public tabStudents()
        {
            InitializeComponent();
        }

        private void InitializeDataSets()
        {
            try
            {
                List<StudentInfo> students = DataService.SelectAllStudentsInfo();
                DataSetInitializer<StudentInfo>.dgvDataSetInitializer(ref dgvStudents, students, new int[] { 1 }, new string[] { "name" });

                List<GroupInfo> groups = DataService.SelectAllGroupsInfo();
                DataSetInitializer<GroupInfo>.ComboBoxDataSetInitializer(ref cbGroup, groups, "id", "group_name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void tabStudents_Load(object sender, EventArgs e)
        {
            InitializeDataSets();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    name = txtName.Text,
                    id_of_group = (int)cbGroup.SelectedValue
                };

                int recAffected = DataService.InsertIntoStudentsTable(student);

                if (recAffected > 0)
                {
                    InitializeDataSets();
                    //NOTE: добавить пометку новых записей
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Student student = new Student
                {
                    id = int.Parse(txtStId.Text),
                    name = txtName.Text,
                    id_of_group = (int)cbGroup.SelectedValue
                };

                int recAffected = DataService.UpdateStudents(student);

                if (recAffected > 0)
                {
                    InitializeDataSets();
                    //NOTE: добавить пометку новых записей
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        //NOTE: mapper here
        private void btnLoadFromEXCEL_Click(object sender, EventArgs e)
        {

        }

        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            //NOTE: add exception handler here
            txtStId.Text = dgvStudents.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvStudents.CurrentRow.Cells["name"].Value.ToString();
            cbGroup.SelectedValue = DataService.GetIdOfGroupByGroupName(dgvStudents.CurrentRow.Cells["group_name"].Value.ToString());
        }
    }
}
