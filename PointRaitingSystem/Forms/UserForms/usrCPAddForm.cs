using MainLib.DBServices;
using MainLib.Session;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public partial class usrCPAddForm : Form
    {
        public usrCPAddForm()
        {
            InitializeComponent();
        }
        public usrCPAddForm(Discipline selectedDiscipline, int SelectedGroupId)
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
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherID(Session.GetCurrentSession().ID);
                DataSetInitializer<Discipline>.ComboBoxDataSetInitializer(ref cbDiscipline, disciplines, "id", "name");
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при инициализации набора данных.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (selectedDiscipline != null)
                cbDiscipline.SelectedItem = selectedDiscipline;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            ControlPoint cp = new ControlPoint
            {
                id_of_user = Session.GetCurrentSession().ID,
                id_of_discipline = (int)cbDiscipline.SelectedValue,
                weight = int.Parse(txtCPWeight.Text),
                Description = txtDescription.Text
            };

            try
            {
                DataService.InsertIntoControlPointsTable(cp);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при создании контрольной точки.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            createStudentsControlPoints();
            this.Close();
        }
        //NOTE: Здесь, возможно, нужно использовать транзакцию.
        private void createStudentsControlPoints()
        {
            try
            {
                int indexOfCP = DataService.GetIndexOfLastControlPoint();
                foreach (Student student in DataService.SelectStudentsByGroupId(groupId))
                {
                    DataService.InsertIntoStudentCPTable(new ControlPointsOfStudents{
                        id_of_controlPoint = indexOfCP,
                        id_of_student = student.id,
                        points = 0
                    });
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при привязки контрольной точки студенту.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
