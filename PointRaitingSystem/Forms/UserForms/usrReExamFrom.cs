using MainLib.DBServices;
using MainLib.Session;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public enum ExamType { Reexam, Exam };

    public partial class usrReExamFrom : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private bool isCellsHiden = false;
        private bool isCommited = false;
        private List<StudentExam> tempStudentExams;
        private List<StudentWithExam> studentWithExams;
        private List<StudentsWithCP> studentsWithCPs;

        public usrReExamFrom(int groupID, int disciplineID, ExamType type)
        {
            InitializeComponent();
            switch(type)
            {
                case ExamType.Exam:
                    GenerateExamEntitiesForStudents(groupID, disciplineID);
                    InitializeDataSetsExam(groupID, disciplineID);
                    break;
                case ExamType.Reexam:
                    InitializeDataSetsReexam(groupID, disciplineID);
                    break;
            }
        }
        public bool IsCommited { get => isCommited; }

        private void FillControlPointInfo(bool isVisible = false)
        {
            gbCPInfo.Visible = isVisible;
            if (!isVisible)
                return;

            ControlPointInfo cpInfo = null;
            try
            {
                int id = (int)dgvStudentsCPs.CurrentRow.Cells[dgvStudentsCPs.SelectedColumns[0].Index - 1].Value;
                cpInfo = DataService.SelectControlPointInfo(id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
            lblAuthor.Text = cpInfo.name;
            lblDiscipline.Text = cpInfo.discipline_name;
            lblWeight.Text = cpInfo.weight.ToString();
            txtDescription.Text = cpInfo.description;
        }
        private void InitializeDataSetsReexam(int groupID, int disciplineID)
        {
            int[] studentsIDs;
            try
            {
                reexamStudentsExamsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvExams, out studentsIDs, out studentWithExams, groupID, disciplineID);
                reexamStudentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudentsCPs, out studentsWithCPs, groupID, disciplineID, studentsIDs);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void InitializeDataSetsExam(int groupID, int disciplineID)
        {
            try
            {
                studentExamDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvExams, groupID, tempStudentExams);
                //reexamStudentsExamsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvExams, out studentsIDs, out studentWithExams, groupID, disciplineID);
                reexamStudentCPsDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudentsCPs, out studentsWithCPs, groupID, disciplineID);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void GenerateExamEntitiesForStudents(int groupID, int disciplineID)
        {
            UserInfo teacher = Session.GetCurrentSession().UserSession;
            tempStudentExams = new List<StudentExam>();
            List<Student> students = null;
            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return;
            }

            foreach (Student student in students)
            {
                tempStudentExams.Add(new StudentExam()
                {
                    id_of_discipline = disciplineID,
                    id_of_student = student.id,
                    id_of_user = teacher.id,
                    date = DateTime.Now.Date,
                    isNotPassed = true
                });
            }
        }


        private void dgvStudentsCPs_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pointsToIns = Convert.ToDouble(dgvStudentsCPs.CurrentCell.Value.ToString().Replace('.', ',')
                                                                                          .Replace('/', ',')
                                                                                          .Replace('б', ',')
                                                                                          .Replace('ю', ',')
                                                                                          .Replace('Ю', ','));
            dgvStudentsCPs.CurrentCell.Value = pointsToIns;
            int id = Convert.ToInt32(dgvStudentsCPs.CurrentRow.Cells[e.ColumnIndex - 1].Value);

            try
            {
                int idOfCP = Convert.ToInt32(dgvStudentsCPs.CurrentRow.Cells[dgvStudentsCPs.CurrentCell.ColumnIndex - 1].Value);
                ControlPointInfo cpInfo = DataService.SelectControlPointInfo(idOfCP);

                if (pointsToIns < 0 || pointsToIns > cpInfo.weight)
                {
                    MessageBox.Show("Введеные баллы превышаеют вес КТ.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStudentsCPs.CurrentCell.Value = 0;
                    return;
                }
                var cpIndex = studentsWithCPs[dgvStudentsCPs.CurrentRow.Index].studentCPs.FindIndex(x => x.id == id);
                studentsWithCPs[dgvStudentsCPs.CurrentRow.Index].studentCPs[cpIndex].points = pointsToIns;
                reexamStudentCPsDataGridViewFactory.CalculateSum(ref dgvStudentsCPs);
                
                //DataService.UpdateStudentCP(pointsToIns, id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при обновлении баллов студента.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvStudentsCPs.CurrentCell.Value = 0;
                return;
            }
        }
        private void dgvStudentsCPs_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedColIndex = dgvStudentsCPs.SelectedColumns[0].Index;
            try
            {
                if (selectedColIndex <= 1 || selectedColIndex >= dgvStudentsCPs.Columns.Count - 1)
                {
                    FillControlPointInfo();
                    isCellsHiden = false;
                    return;
                }

                if (!isCellsHiden)
                {
                    foreach (DataGridViewColumn column in dgvStudentsCPs.Columns)
                    {
                        if (column.Index > 1 && column.Index < dgvStudentsCPs.Columns.Count - 1 && selectedColIndex > 1 && selectedColIndex < dgvStudentsCPs.Columns.Count - 1)
                        {
                            if (column.Index != selectedColIndex - 1 && column.Index != selectedColIndex)
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
                    foreach (DataGridViewColumn column in dgvStudentsCPs.Columns)
                    {
                        if (!column.Name.Contains("id") )
                        {
                            column.Visible = true;
                            column.ReadOnly = true;
                        }
                    }
                    reexamStudentCPsDataGridViewFactory.CalculateSum(ref dgvStudentsCPs);
                    isCellsHiden = false;
                    FillControlPointInfo();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void dgvExams_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double points = Convert.ToDouble(dgvExams.CurrentCell.Value.ToString().Replace('.', ',')
                                                                                         .Replace('/', ',')
                                                                                         .Replace('б', ',')
                                                                                         .Replace('ю', ',')
                                                                                         .Replace('Ю', ','));

            if (points > 20)
            {
                MessageBox.Show("Введеные баллы превышаеют вес КТ.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvExams.CurrentCell.Value = 0;
                return;
            }

            dgvExams.CurrentCell.Value = points;

            try
            {
                dgvExams.CurrentCell.Value = points;
                studentWithExams[dgvExams.CurrentRow.Index].examInfo.points = points;
                studentWithExams[dgvExams.CurrentRow.Index].examInfo.CountExamGrade();
                dgvExams.CurrentRow.Cells["examGrade"].Value = studentWithExams[dgvExams.CurrentRow.Index].examInfo.grade;
                dgvExams.CurrentRow.Cells["recGrade"].Value = studentWithExams[dgvExams.CurrentRow.Index].examInfo.CountRecommendedGrade((double)dgvExams.CurrentRow.Cells["sum"].Value);
                //DataService.UpdateStudentExamsResults();
            }
            catch (Exception)
            {

            }
        }
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 1)
            {
                reexamStudentsExamsDataGridViewFactory.ChangeStudentCurrentPoints(ref dgvExams, ref dgvStudentsCPs);
                dgvExams.CurrentRow.Cells["recGrade"].Value = studentWithExams[dgvExams.CurrentRow.Index].examInfo.CountRecommendedGrade((double)dgvExams.CurrentRow.Cells["sum"].Value);
            }
        }
        private void dgvExams_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if ((double)dgvExams.CurrentRow.Cells[2].Value < 50)
            {
                tsslInfo.Text = "Студент не допущен до экзамена.";
                e.Cancel = true;
                return;
            }
        }
        private void usrReExamFrom_Load(object sender, EventArgs e)
        {

        }
    }
}
