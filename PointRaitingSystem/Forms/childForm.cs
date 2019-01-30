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
        public childForm()
        {
            InitializeComponent();
        }
        public childForm(Discipline selectedDiscipline, int SelectedGroupId)
        {
            InitializeComponent();
            InitializeDataSets(selectedDiscipline);
            groupId = SelectedGroupId;
        }

        private int groupId;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();


        private void InitializeDataSets(Discipline selectedDiscipline = null)
        {
            try
            {
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherID(CurrentSession.GetCurrentSession().ID);
                DataSetInitializer<Discipline>.ComboBoxDataSetInitializer(ref cbDiscipline, disciplines, "id", "discipline_name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            if (selectedDiscipline != null)
                cbDiscipline.SelectedItem = selectedDiscipline;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ControlPoint cp = new ControlPoint
            {
                id_of_teacher = CurrentSession.GetCurrentSession().ID,
                id_of_discipline = (int)cbDiscipline.SelectedValue,
                weight = int.Parse(txtCPWeight.Text),
                date = dateTimePicker.Value,
                Description = txtDescription.Text
            };

            try
            {
                DataService.InsertIntoControlPointsTable(cp);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }

            createStudentsControlPoints();
            this.Close();
        }
        private void createStudentsControlPoints()
        {
            try
            {
                int indexOfCP = DataService.GetIndexOfLastControlPoint();
                foreach (Student student in DataService.SelectStudentsByGroupId(groupId))
                {
                    DataService.InsertIntoStudentCPTable(new ControlPointsOfStudents{ id_of_cp = indexOfCP, id_of_student = student.id, points = 0});
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
