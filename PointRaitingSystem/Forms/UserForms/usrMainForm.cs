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
        private bool isCellsHiden = false;

        private void tsmiDataSoruce_Click(object sender, EventArgs e)
        {

        }
        private void MainForm_Load(object sender, EventArgs e)
        {
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
       
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
            }
        }
        private void cbDiscipline_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
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
                List<Group> groups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer<Group>.ComboBoxDataSetInitializer(ref cbGroups, groups, "id", "group_name");
                //cbDiscipline
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (int)cbGroups.SelectedValue);
                DataSetInitializer<Discipline>.ComboBoxDataSetInitializer(ref cbDiscipline, disciplines, "id", "discipline_name");
                //dgvStudents dataset
                //List<Student> students = DataService.SelectStudentsByGroupId((int)cbGroups.SelectedValue);
                //DataSetInitializer<Student>.dgvDataSetInitializer(ref dgvStudents, students, new int[] { 0, 2 }, new string[] { "name" });
                studentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (int)cbGroups.SelectedValue, (int)cbDiscipline.SelectedValue);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            //tsslTeacherName
            tsslTeacherName.Text = Session.GetCurrentSession().UserName;
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
            DataService.UpdateStudentCP(pointsToIns, id);
            studentCPsDataGridViewFactory.CalculateSum(ref dgvStudents);
        }
        //HACK: продолжаю порожаться
        private void dgvStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedColIndex = dgvStudents.SelectedColumns[0].Index;
            if (!isCellsHiden)
            {
                foreach (DataGridViewColumn column in dgvStudents.Columns)
                {
                    if (column.Index > 1 && column.Index < dgvStudents.Columns.Count - 1 && selectedColIndex > 1 && selectedColIndex < dgvStudents.Columns.Count - 1)
                    {
                        if (column.Index != selectedColIndex - 1 && column.Index != selectedColIndex)
                            column.Visible = false;
                    }
                }
                isCellsHiden = !isCellsHiden;
            }
            else
            {
                foreach (DataGridViewColumn column in dgvStudents.Columns)
                {
                    if (!column.Name.Contains("id"))
                    {
                            column.Visible = true;
                    }
                }
                isCellsHiden = !isCellsHiden;
            }
        }
    }
}
