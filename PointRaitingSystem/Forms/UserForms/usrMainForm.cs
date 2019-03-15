using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;

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
        private bool isCellsHiden = false;
       
        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDiscipline.Text = string.Empty;
            cbDiscipline.SelectedIndex = -1;
            try
            {
                cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
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


        //TODO: инкапсулировть
        private void InitializeDataSets()
        {
            try
            {
                //cbGroup
                List<Group> groups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer<Group>.ComboBoxDataSetInitializer(ref cbGroups, groups, "id", "name");
                //cbDiscipline
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                DataSetInitializer<Discipline>.ComboBoxDataSetInitializer(ref cbDiscipline, disciplines, "id", "full_name");
                //dgvStudents dataset
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
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
        private void bindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usrSettingsForm usrSettingsForm = new usrSettingsForm();
            usrSettingsForm.ShowDialog();
            InitializeDataSets();
        }
        private void dgvStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int pointsToIns = Convert.ToInt32(dgvStudents.CurrentCell.Value),
                id = Convert.ToInt32(dgvStudents.CurrentRow.Cells[e.ColumnIndex - 1].Value);
            try
            {
                DataService.UpdateStudentCP(pointsToIns, id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при обновлении баллов студента.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        }
    }
}
