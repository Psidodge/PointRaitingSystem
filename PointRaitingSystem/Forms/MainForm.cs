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
    public partial class MainForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        public MainForm() 
        {
            InitializeComponent();
            InitializeDataSets();
        }

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

        //TODO: инкапсулировть
        private void InitializeDataSets()
        {
            //tsslTeacherName
            tsslTeacherName.Text = CurrentSession.GetCurrentSession().UserName;
            //cbGroup
            cbGroups.DataSource = DataService.SelectGroupsByTeacherLogin(CurrentSession.GetCurrentSession().ID);
            cbGroups.ValueMember = "id";
            cbGroups.DisplayMember = "group_name";
            //cbDiscipline
            cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherLogin(CurrentSession.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
            cbDiscipline.ValueMember = "id";
            cbDiscipline.DisplayMember = "discipline_name";
            //dgvStudents dataset
            dgvStudents.AutoGenerateColumns = true;
            dgvStudents.DataSource = DataService.SelectStudentsByGroupId((int)cbGroups.SelectedValue);
            dgvStudents.Columns[0].Visible = false;
            dgvStudents.Columns[2].Visible = false;
            dgvStudents.Columns["name"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //dgvStudentCPs
            dgvStudentCPs.AutoGenerateColumns = true;
        }

        //NOTE: FIX HERE PLS
        private void create_dgvStudentCPsCells()
        {
            dgvStudentCPs.Columns.Clear();
            int studentId = (int)dgvStudents.CurrentRow.Cells[0].Value,
                iter = 0;
            //foreach(ControlPoints scp in DataService.SelectControlPoints(((Disciplines)cbDiscipline.SelectedItem).id))
            foreach (ControlPointsOfStudents scp in DataService.SelectStudentCPById(studentId, (int)cbDiscipline.SelectedValue))
            {
                dgvStudentCPs.Columns.Add(string.Format("CP{0}", iter+1), string.Format("КТ {0}", iter + 1));
                if(dgvStudentCPs.Rows.Count == 0)
                    dgvStudentCPs.Rows.Add();
                dgvStudentCPs.CurrentRow.Cells[iter].Value = scp.points;
                //dgvStudents.Columns[iter].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                iter++;
            }
        }

        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDiscipline.Text = string.Empty;
            cbDiscipline.SelectedIndex = -1;
            cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherLogin(CurrentSession.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
            dgvStudents.DataSource = DataService.SelectStudentsByGroupId((int)cbGroups.SelectedValue);
        }
        //NOTE: refactor here
        private void btnCreateCP_Click(object sender, EventArgs e)
        {
            childForm form = new childForm((Disciplines)cbDiscipline.SelectedItem, (int)cbGroups.SelectedValue);
            form.ShowDialog();
        }

        private void btnShowCP_Click(object sender, EventArgs e)
        {
            childForm2 form2 = new childForm2((Disciplines)cbDiscipline.SelectedItem);
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
            //TODO: Create Method to get cp by id and replace that
            List<ControlPointsOfStudents> studentsCPs = DataService.SelectStudentCPById(studentId, disciplineId);
            DataService.UpdateStCP(points, studentsCPs[e.ColumnIndex].id);
        }
    }
}
