using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private int cbGroupsPrevIndex = 0;

        private void tsmiDataSoruce_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            create_dgvStudentCPsCells();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        //NOTE: FIX HERE PLS
        //EXC: возникает исключение, когд список дисциплин пуст
        private void create_dgvStudentCPsCells()
        {
            dgvStudentCPs.Columns.Clear();
            int studentId = (int)dgvStudents.CurrentRow.Cells[0].Value,
                iter = 0;

            foreach (ControlPointsOfStudents scp in DataService.SelectStudentControPoints(studentId, (int)cbDiscipline.SelectedValue))
            {
                dgvStudentCPs.Columns.Add(string.Format("CP{0}", iter+1), string.Format("КТ {0}", iter + 1));
                if(dgvStudentCPs.Rows.Count == 0)
                    dgvStudentCPs.Rows.Add();
                dgvStudentCPs.CurrentRow.Cells[iter].Value = scp.points;
                iter++;
            }
        }
        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDiscipline.Text = string.Empty;
            cbDiscipline.SelectedIndex = -1;
            try
            {
                cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherIdAndGroupId(CurrentSession.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                dgvStudents.DataSource = DataService.SelectStudentsByGroupId((int)cbGroups.SelectedValue);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        //NOTE: refactor here
        private void btnCreateCP_Click(object sender, EventArgs e)
        {
            usrCPAddForm form = new usrCPAddForm((Discipline)cbDiscipline.SelectedItem, (int)cbGroups.SelectedValue);
            form.ShowDialog();
        }
        private void btnShowCP_Click(object sender, EventArgs e)
        {
            usrCPShowForm form2 = new usrCPShowForm((Discipline)cbDiscipline.SelectedItem);
            form2.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }
        private void dgvStudents_SelectionChanged(object sender, EventArgs e)
        {
            create_dgvStudentCPsCells();
        }
        private void dgvStudentCPs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //TODO: Validation here
            int studentId = (int)dgvStudents.CurrentRow.Cells[0].Value,
                disciplineId = (int)cbDiscipline.SelectedValue,
                points = int.Parse(dgvStudentCPs.CurrentRow.Cells[e.ColumnIndex].Value.ToString());
            try
            {
                List<ControlPointsOfStudents> studentsCPs = DataService.SelectStudentControPoints(studentId, disciplineId);
                DataService.UpdateStudentCP(points, studentsCPs[e.ColumnIndex].id);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void dgvStudentCPs_SelectionChanged(object sender, EventArgs e)
        {
            int studentId = (int)dgvStudents.CurrentRow.Cells[0].Value,
                disciplineId = (int)cbDiscipline.SelectedValue;

            ControlPoint cp = null;
            try
            {
                cp = DataService.SelectControlPointsInfoByStIdAndCpIndex(studentId, disciplineId, dgvStudentCPs.CurrentCell.ColumnIndex);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            if (cp == null)
            {
                clearControlPointsInformation();
                return;
            }

            try
            {
                fillControlPointsInformation(DataService.SelectTeacherById(cp.id_of_teacher).Name,
                                             DataService.SelectDisciplineById(cp.id_of_discipline).discipline_name,
                                             cp.date.ToShortDateString(), cp.weight.ToString(), txtDescription.Text = cp.Description);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbGroupsPrevIndex = cbGroups.SelectedIndex;
        }


        //TODO: инкапсулировть
        private void InitializeDataSets()
        {
            try
            {
                //cbGroup
                List<Group> groups = DataService.SelectGroupsByTeacherId(CurrentSession.GetCurrentSession().ID);
                DataSetInitializer<Group>.ComboBoxDataSetInitializer(ref cbGroups, groups, "id", "group_name");
                //cbDiscipline
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(CurrentSession.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                DataSetInitializer<Discipline>.ComboBoxDataSetInitializer(ref cbDiscipline, disciplines, "id", "discipline_name");
                //dgvStudents dataset
                List<Student> students = DataService.SelectStudentsByGroupId((int)cbGroups.SelectedValue);
                DataSetInitializer<Student>.dgvDataSetInitializer(ref dgvStudents, students, new int[] { 0, 2 }, new string[] { "name" });
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            //tsslTeacherName
            tsslTeacherName.Text = CurrentSession.GetCurrentSession().UserName;
            //dgvStudentCPs
            dgvStudentCPs.AutoGenerateColumns = true;
        }
        private void fillControlPointsInformation(string cpCreator, string discipline, string date, string weight, string description)
        {
            lblTeacher.Text = cpCreator;
            lblDiscipline.Text = discipline;
            lblbDate.Text = date;
            lblWeight.Text = weight;
            txtDescription.Text = description;
        }
        private void clearControlPointsInformation()
        {
            lblTeacher.Text = string.Empty;
            lblDiscipline.Text = string.Empty;
            lblbDate.Text = string.Empty;
            lblWeight.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void bindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usrSettingsForm usrSettingsForm = new usrSettingsForm();
            usrSettingsForm.ShowDialog();
            InitializeDataSets();
        }
    }
}
