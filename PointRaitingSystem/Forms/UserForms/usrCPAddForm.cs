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

        public usrCPAddForm(Discipline selectedDiscipline, int SelectedGroupId, object selectedDisciplineIndex)
        {
            InitializeComponent();
            groupId = SelectedGroupId;
            InitializeDataSets(selectedDisciplineIndex, selectedDiscipline);
        }

        private int groupId;
        private double sumOfUsedPoints,
                       maxSumOfCPs = 80;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private ControlPoint tempCP = null;


        private void InitializeDataSets(object selectedDisciplineValue, Discipline selectedDiscipline = null)
        {
            try
            {
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, groupId);
                DataSetInitializer.ComboBoxDataSetInitializer<Discipline>(ref cbDiscipline, disciplines, "id", "full_name");
                cbDiscipline.SelectedValue = selectedDisciplineValue;
                sumOfUsedPoints = DataService.GetSumOfPointsUsed(groupId, (int)selectedDisciplineValue);
                tsslPointsLeft.Text = string.Format("{0} {1} баллов", tsslPointsLeft.Text, sumOfUsedPoints.ToString());

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
            tempCP = cp;
            try
            {
                tempCP.id = DataService.InsertIntoControlPointsTable(cp);
                if (MessageBox.Show("Сохранить как шаблон?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    DataService.InsertIntoControlPointTemplateTable(cp.ConvertToTemplate());
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
                if (tempCP == null)
                    return;

                int idOfCP = tempCP.id;
                //int indexOfCP = DataService.GetIndexOfLastControlPoint();
                foreach (Student student in DataService.SelectStudentsByGroupId(groupId))
                {
                    DataService.InsertIntoStudentCPTable(new ControlPointsOfStudents{
                        id_of_controlPoint = idOfCP,
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
        private void txtCPWeight_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            double weight = 0;

            if (!double.TryParse(txtCPWeight.Text.Replace('.', ','), out weight))
            {
                txtCPWeight.Text = string.Empty;
                lblValidationInfo.Text = "Неверный формат.";
                return;
            }

            if((maxSumOfCPs - (sumOfUsedPoints + weight)) < 0)
            {
                txtCPWeight.Text = string.Empty;
                lblValidationInfo.Text = "Вводимый вес КТ превышает 80 баллов.";
                return;
            }
        }
        private void txtCPWeight_TextChanged(object sender, EventArgs e)
        {
            double weight = 0;
            if (!double.TryParse(txtCPWeight.Text.Replace('.','.'), out weight))
                return;//NOTE: генерить исключение

            tsslPointsRemain.Text = string.Format("Останется: {0} баллов", (maxSumOfCPs - (sumOfUsedPoints + weight)).ToString());
        }
    }
}
