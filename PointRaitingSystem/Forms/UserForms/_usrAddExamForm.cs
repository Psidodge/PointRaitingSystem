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
    public partial class usrAddExamForm : Form
    {
        private List<StudentExam> tempStudentExams;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private uint _disciplineID;
        private bool isCommited = false;

        public usrAddExamForm(uint groupID, uint disciplineID)
        {
            InitializeComponent();
            _disciplineID = disciplineID;
            GenerateExamEntitiesForStudents(groupID, disciplineID);
            InitializeDataSets(groupID);
        }
        public bool IsCommited { get => isCommited; }

        private void InitializeDataSets(uint groupID)
        {
            try
            {
                studentExamDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudentExams, groupID, tempStudentExams);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void GenerateExamEntitiesForStudents(uint groupID, uint disciplineID)
        {
            UserInfo teacher = Session.GetCurrentSession().UserSession;
            tempStudentExams = new List<StudentExam>();
            List<Student> students = null;
            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                return;
            }

            foreach(Student student in students)
            {
                tempStudentExams.Add(new StudentExam()
                {
                    id_of_discipline = disciplineID,
                    id_of_student = student.id,
                    id_of_user = teacher.id,
                    date = DateTime.Now.Date
                });
            }
        }
        private void dgvStudentExams_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double points = Convert.ToDouble(dgvStudentExams.CurrentCell.Value.ToString().Replace('.', ',')
                                                                                         .Replace('/', ',')
                                                                                         .Replace('б', ',')
                                                                                         .Replace('ю', ',')
                                                                                         .Replace('Ю', ','));

            if(points > 20)
            {
                MessageBox.Show("Введеные баллы превышаеют вес КТ.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvStudentExams.CurrentCell.Value = 0;
                return;
            }

            dgvStudentExams.CurrentCell.Value = points;
            tempStudentExams[dgvStudentExams.CurrentRow.Index].points = points;
            tempStudentExams[dgvStudentExams.CurrentRow.Index].CountExamGrade();
            dgvStudentExams.CurrentRow.Cells["examGrade"].Value = tempStudentExams[dgvStudentExams.CurrentRow.Index].grade;
            dgvStudentExams.CurrentRow.Cells["recGrade"].Value = tempStudentExams[dgvStudentExams.CurrentRow.Index].CountRecommendedGrade();

            //if (tempStudentExams[dgvStudentExams.CurrentRow.Index].points == 0 || (int)dgvStudentExams.CurrentRow.Cells["recGrade"].Value == 2)
              //  tempStudentExams[dgvStudentExams.CurrentRow.Index].isNotPassed = true;
            //else
            //    tempStudentExams[dgvStudentExams.CurrentRow.Index].isNotPassed = false;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DataService.InsertIntoStudentExam(tempStudentExams))
                {
                    tsslInfo.Text = "Успешно сохранено.";
                    isCommited = true;
                }
                else
                    tsslInfo.Text = "Произошла ошибка при проведении транзакции.";
            }
            catch(Exception ex)
            {
                tsslInfo.Text = "Произошла ошибка при проведении транзакции.";
                logger.Error(ex);
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dgvStudentExams_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((double)dgvStudentExams.CurrentRow.Cells[2].Value < 50)
            {
                tsslInfo.Text = "Студент недопущен до экзамена.";
                e.Cancel = true;
                return;
            }
        }
    }
}
