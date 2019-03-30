using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;
using MainLib.ReportsFactory;

namespace PointRaitingSystem
{
    public partial class usrMainForm : Form
    {
        public usrMainForm() 
        {
            InitializeComponent();
            InitializeDataSets();
            tsslCurrentDate.Text = DateTime.Now.ToShortDateString();
        }

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private int cbGroupsPrevIndex = 0;
        private int[] certificationIndexes = null;
        private bool isCellsHiden = false;
       
        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDiscipline.Text = string.Empty;
            cbDiscipline.SelectedIndex = -1;
            try
            {
                cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
                studentCPsDataGridViewFactory.InsertCertifications(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue, out certificationIndexes);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cbDiscipline_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
                FillControlPointInfo();
                isCellsHiden = false;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCreateCP_Click(object sender, EventArgs e)
        {
            usrCPAddForm form = new usrCPAddForm((Discipline)cbDiscipline.SelectedItem, (int)cbGroups.SelectedValue);
            form.ShowDialog();
            studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
            studentCPsDataGridViewFactory.InsertCertifications(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue, out certificationIndexes);
        }
        private void btnShowCP_Click(object sender, EventArgs e)
        {
            usrCPShowForm form2 = new usrCPShowForm((Discipline)cbDiscipline.SelectedItem);
            form2.Show();
        }
        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillControlPointInfo();
            isCellsHiden = false;
            cbGroupsPrevIndex = cbGroups.SelectedIndex;
        }


        private void InitializeDataSets()
        {
            try
            {
                //cbGroup
                List<Group> groups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer.ComboBoxDataSetInitializer<Group>(ref cbGroups, groups, "id", "name");
                //cbDiscipline
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                DataSetInitializer.ComboBoxDataSetInitializer<Discipline>(ref cbDiscipline, disciplines, "id", "full_name");
                //dgvStudents dataset
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
                //insert certification
                studentCPsDataGridViewFactory.InsertCertifications(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue, out certificationIndexes);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //MessageBox.Show("Произошла ошибка при инициализации набора данных.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tsslTeacherName
            tsslTeacherName.Text = Session.GetCurrentSession().UserName;
        }
        private void FillControlPointInfo(bool isVisible = false)
        {
            gbCPInfo.Visible = isVisible;
            if (!isVisible)
                return;

            ControlPointInfo cpInfo = null;
            try
            {
                int id = (int)dgvStudents.CurrentRow.Cells[dgvStudents.SelectedColumns[0].Index - 1].Value;
                cpInfo = DataService.SelectControlPointInfo(id);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            lblAuthor.Text = cpInfo.name;
            lblDiscipline.Text = cpInfo.discipline_name;
            lblWeight.Text = cpInfo.weight.ToString();
            txtDescription.Text = cpInfo.description;
        }
        private void FillCertificationInfo(bool isVisible = false, int certIndex = -1)
        {
            gbCertificationInfo.Visible = isVisible;
            if (!isVisible || certIndex == -1)
                return;

            StudentCertification studentCertification = null;
            try
            {
                int studentID = (int)dgvStudents.CurrentRow.Cells[0].Value;
                var stCeritifications = DataService.SelectStudentCertifications((int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue, studentID);
                studentCertification = stCeritifications[certIndex];
                lblCertCreator.Text = DataService.SelectTeacherById(studentCertification.id_of_user).Name.ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            lblMaxPointsSum.Text = studentCertification.GetMaxSumOfPoints().ToString();
            lblDate.Text = studentCertification.date.ToShortDateString();
        }
        private void bindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usrSettingsForm usrSettingsForm = new usrSettingsForm();
            usrSettingsForm.ShowDialog();
            InitializeDataSets();
        }
        private void dgvStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pointsToIns = Convert.ToDouble(dgvStudents.CurrentCell.Value.ToString().Replace('.',','));
            int id = Convert.ToInt32(dgvStudents.CurrentRow.Cells[e.ColumnIndex - 1].Value);
            
            try
            {
                int idOfCP = Convert.ToInt32(dgvStudents.CurrentRow.Cells[dgvStudents.CurrentCell.ColumnIndex - 1].Value);
                ControlPointInfo cpInfo = DataService.SelectControlPointInfo(idOfCP);

                if (pointsToIns < 0 || pointsToIns > cpInfo.weight)
                { 
                    MessageBox.Show("Введеные баллы превышаеют вес КТ.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStudents.CurrentCell.Value = 0;
                    return;
                }
                DataService.UpdateStudentCP(pointsToIns, id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при обновлении баллов студента.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvStudents.CurrentCell.Value = 0;
                return;
            }
            studentCPsDataGridViewFactory.CalculateSum(ref dgvStudents);
        }
        private void dgvStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedColIndex = dgvStudents.SelectedColumns[0].Index;
            try
            {
                if (selectedColIndex <= 1 || selectedColIndex >= dgvStudents.Columns.Count - 1)
                {
                    FillControlPointInfo();
                    isCellsHiden = false;
                    return;
                }

                for (int i = 0; i < certificationIndexes.Length; i++)
                {
                    if (selectedColIndex == certificationIndexes[i])
                    {
                        FillControlPointInfo();
                        FillCertificationInfo(true, i);
                        isCellsHiden = false;
                        return;
                    }
                }


                if (!isCellsHiden)
                {
                    foreach (DataGridViewColumn column in dgvStudents.Columns)
                    {
                        if (column.Index > 1 && column.Index < dgvStudents.Columns.Count - 1 && selectedColIndex > 1 && selectedColIndex < dgvStudents.Columns.Count - 1)
                        {
                            if(column.Index != selectedColIndex - 1 && column.Index != selectedColIndex)
                                column.Visible = false;
                            if (column.Index == selectedColIndex)
                                column.ReadOnly = false;
                        }
                    }
                    isCellsHiden = true;
                    FillCertificationInfo();
                    FillControlPointInfo(true);
                }
                else
                {
                    foreach (DataGridViewColumn column in dgvStudents.Columns)
                    {
                        if (!column.Name.Contains("id"))
                        {
                            column.Visible = true;
                            column.ReadOnly = true;
                        }
                    }
                    isCellsHiden = false;
                    FillControlPointInfo();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCertification_Click(object sender, EventArgs e)
        {
            usrCertificationAddForm form = new usrCertificationAddForm(((Group)cbGroups.SelectedItem).name, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
            form.ShowDialog();
            studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
            studentCPsDataGridViewFactory.InsertCertifications(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue, out certificationIndexes);
        }
        private void tsmiCertification_Click(object sender, EventArgs e)
        {
            
        }
        private void tsmiExam_Click(object sender, EventArgs e)
        {

        }
    }
}
