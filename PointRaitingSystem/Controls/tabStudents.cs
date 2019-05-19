using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    public partial class tabStudents : UserControl
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool isDSInitialized = false;
        private List<StudentInfo> originStudentsList = null;
        private Dictionary<string, string> allias;

        public tabStudents()
        {
            InitializeComponent();
        }

        public override void Refresh()
        {
            InitializeDataSets();
        }

        private void InitializeDataSets()
        {
            try
            {
                List<StudentInfo> students = DataService.SelectAllStudentsInfo();
                SetHeadersAllias();
                DataSetInitializer.dgvDataSetInitializer<StudentInfo>(ref dgvStudents, students, allias, new int[] { 0, 3 }, new string[] { "name" });

                if (!isDSInitialized)
                {
                    List<GroupInfo> groups = DataService.SelectAllGroupsInfo();
                    DataSetInitializer.ComboBoxDataSetInitializer<GroupInfo>(ref cbGroup, groups, "id", "name");
                    DataSetInitializer.ComboBoxDataSetInitializer<GroupInfo>(ref cbGroupFrom, new List<GroupInfo>(groups), "id", "name");
                    DataSetInitializer.ComboBoxDataSetInitializer<GroupInfo>(ref cbGroupTo, new List<GroupInfo>(groups), "id", "name");
                    groups.Insert(0, new GroupInfo() { });
                    DataSetInitializer.ComboBoxDataSetInitializer<GroupInfo>(ref cbGroupFilter, new List<GroupInfo>(groups), "id", "name");
                    isDSInitialized = true;
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void SetHeadersAllias()
        {
            allias = new Dictionary<string, string>();
            allias.Add("name", "ФИО");
            allias.Add("group_name", "Группа");
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
                    id_of_group = (uint)cbGroup.SelectedValue
                };

                uint recAffected = DataService.InsertIntoStudentsTable(student);

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
                    id = uint.Parse(txtStId.Text),
                    name = txtName.Text,
                    id_of_group = (uint)cbGroup.SelectedValue
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
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null)
                return;
            //NOTE: add exception handler here
            txtStId.Text = dgvStudents.CurrentRow.Cells["id"].Value.ToString();
            txtName.Text = dgvStudents.CurrentRow.Cells["name"].Value.ToString();
            cbGroup.SelectedIndex = cbGroup.FindStringExact(dgvStudents.CurrentRow.Cells["group_name"].Value.ToString());
        }
        private void btnApply_Click(object sender, EventArgs e)
        {
            if (checkBoxOnlySelecetdStudent.Checked)
                UpdateSingleStudent();
            else
                UpdateGroupOfStudents();
        }
        private void checkBoxOnlySelecetdStudent_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxOnlySelecetdStudent.Checked)
                {
                    gbTransferInfo.Text = "Перевести студента в другую группу";
                    lblStudentName.Text = dgvStudents.CurrentRow.Cells["name"].Value.ToString();
                    cbGroupFrom.SelectedIndex = cbGroup.SelectedIndex;
                    studentNamePanel.Visible = true;
                }
                else
                {
                    gbTransferInfo.Text = "Перевести студентов в другую группу";
                    studentNamePanel.Visible = false;
                }
            }
            catch (NullReferenceException) { }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void UpdateSingleStudent()
        {
            try
            {
                Student student = new Student
                {
                    id = uint.Parse(txtStId.Text),
                    name = txtName.Text,
                    id_of_group = (uint)cbGroupTo.SelectedValue
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
        private void UpdateGroupOfStudents()
        {
            List<StudentInfo> students = null;
            try
            {
                students = (List<StudentInfo>)dgvStudents.DataSource;//DataService.SelectAllStudentsInfo();
                students = (from st in students
                            where st.id_of_group == (uint)cbGroupFrom.SelectedValue
                            select st).ToList();
            }
            catch(Exception e)
            {
                logger.Error(e);
            }


            foreach (StudentInfo student in students)
            {
                try
                {
                    Student studentToUpdate = new Student
                    {
                        id = student.id,
                        name = student.name,
                        id_of_group = (uint)cbGroupTo.SelectedValue
                    };

                    if (DataService.UpdateStudents(studentToUpdate) > 0)
                    {
                        InitializeDataSets();
                    }
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                }
            }
        }

        private void btnAddFilter_Click(object sender, EventArgs e)
        {
            List<StudentInfo> tempListStudents = (List<StudentInfo>)dgvStudents.DataSource;

            if (originStudentsList == null)
                originStudentsList = (List<StudentInfo>)dgvStudents.DataSource;

            if (((GroupInfo)cbGroupFilter.SelectedItem).name != null)
                tempListStudents = tempListStudents.Where(x => x.group_name == ((GroupInfo)cbGroupFilter.SelectedItem).name).ToList();

            if (!string.IsNullOrWhiteSpace(txtStudentName.Text))
                tempListStudents = tempListStudents.Where(x => x.name.StartsWith(txtStudentName.Text)).ToList();

            DataSetInitializer.dgvDataSetInitializer<StudentInfo>(ref dgvStudents, tempListStudents, allias, new int[] { 0, 3 }, new string[] { "name" });
        }
        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            DataSetInitializer.dgvDataSetInitializer<StudentInfo>(ref dgvStudents, originStudentsList, allias, new int[] { 0, 3 }, new string[] { "name" });
        }
    }
}
