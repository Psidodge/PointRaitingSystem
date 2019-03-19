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

namespace PointRaitingSystem
{
    public partial class usrCertificationAddForm : Form
    {
        public usrCertificationAddForm()
        {
            InitializeComponent();
        }
        public usrCertificationAddForm(string groupName, int groupID, int disciplineID)
        {
            InitializeComponent();
            txtGroupName.Text = groupName;
            dataSetInitializer(groupID, disciplineID);
            this.groupID = groupID;
            this.disciplineID = disciplineID;
        }

        private int groupID,
                    disciplineID;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();



        private void dataSetInitializer(int groupID, int disciplineID)
        {
            try
            {
                List<StudentControlPoint> controlPoints = DataService.SelectStudentControPointsGroupDisc(groupID, disciplineID)
                                                        .GroupBy(g => g.id_of_controlPoint)
                                                        .Select(s => s.First())
                                                        .ToList();

                DataSetInitializer.ComboBoxDataSetInitializer<StudentControlPoint>(ref cbPrevCP, controlPoints, "id_of_controlPoint", "description");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            List<Student> students = null;

            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                tsslInfo.Text = "Ошибка при подключении к базе данных";
            }

            foreach (Student student in students)
            {
                var certification = new StudentCertification()
                                    {
                                        id_of_student = student.id,
                                        id_of_prev_cp = (int)cbPrevCP.SelectedValue,
                                        id_of_discipline = disciplineID,
                                        date = dtpDate.Value.Date
                                    };
                try
                {
                    certification.CountGrade(disciplineID, (int)cbPrevCP.SelectedValue);
                    DataService.InsertIntoStudentCertification(certification);
                }
                catch (Exception ex)
                {
                    logger.Error(ex);
                    tsslInfo.Text = "Ошибка при добавлении записи";
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}
