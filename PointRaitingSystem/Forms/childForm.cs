using MainLib.DBServices;
using MainLib.Session;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public partial class childForm : Form
    {
        private int groupId;
        public childForm()
        {
            InitializeComponent();
        }
        public childForm(Disciplines selectedDiscipline, int SelectedGroupId)
        {
            InitializeComponent();
            InitializeDataSets(selectedDiscipline);
            groupId = SelectedGroupId;
        }


        private void childForm_Load(object sender, EventArgs e)
        {

        }
        private void InitializeDataSets(Disciplines selectedDiscipline = null)
        {
            cbDiscipline.DataSource = DataService.SelectDisciplines(CurrentSession.GetCurrentSession().ID);
            cbDiscipline.ValueMember = "id";
            cbDiscipline.DisplayMember = "discipline_name";
            if (selectedDiscipline != null)
                cbDiscipline.SelectedItem = selectedDiscipline;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ControlPoints cp = new ControlPoints
            {
                id_of_teacher = CurrentSession.GetCurrentSession().ID,
                id_of_discipline = (int)cbDiscipline.SelectedValue,
                weight = int.Parse(txtCPWeight.Text),
                date = dateTimePicker.Value,
                Description = txtDescription.Text
            };
            DataService.InsertIntoCP(cp);
            createStudentsControlPoints();
            this.Close();
        }
        private void createStudentsControlPoints()
        {
            int indexOfCP = DataService.GetIndexOfLastCP();
            foreach (Students student in DataService.SelectStudentsByGroupId(groupId))
            {
                DataService.InsertIntoStCP(new ControlPointsOfStudents{ id_of_cp = indexOfCP, id_of_student = student.id, points = 0});
            }
        }
    }
}
