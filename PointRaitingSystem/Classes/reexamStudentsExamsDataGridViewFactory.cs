using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    class reexamStudentsExamsDataGridViewFactory
    {
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, out int[] studentsIDs, out List<StudentWithExam> studentWithExams, int groupId, int disciplineID)
        {
            studentsIDs = null;
            dgv.Columns.Clear();

            studentWithExams = GenerateStudentWithExamsList(groupId, disciplineID);
            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentWithExams);
            if (columns == null)
                return;

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentWithExams.Count);

            studentsIDs = new int[studentWithExams.Count];

            for (int i = 0; i < studentWithExams.Count; i++)
            {
                studentsIDs[i] = studentWithExams[i].studentID;
                dgv.Rows[i].Cells[0].Value = studentWithExams[i].studentID;
                dgv.Rows[i].Cells[1].Value = studentWithExams[i].studentName;
                dgv.Rows[i].Cells[2].Value = studentWithExams[i].examInfo.GetMaxStudentScore();
                if ((double)dgv.Rows[i].Cells[2].Value < 50)
                    dgv.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
                dgv.Rows[i].Cells[3].Value = studentWithExams[i].examInfo.id;
                dgv.Rows[i].Cells[4].Value = studentWithExams[i].examInfo.points;
                dgv.Rows[i].Cells[5].Value = 2;
                dgv.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                dgv.Rows[i].Cells[6].Value = 2;
            }
        }
        public static void ChangeStudentCurrentPoints(ref DataGridView dgvExams, ref DataGridView dgvStudentsCPs)
        {
            double currentPoints;

            for (int i = 0; i < dgvExams.Rows.Count; i++)
            {
                currentPoints = (double)dgvStudentsCPs.Rows[i].Cells["sum"].Value;

                dgvExams.Rows[i].Cells[2].Value = currentPoints;

                if (currentPoints > 50d)
                    dgvExams.Rows[i].Cells[2].Style.BackColor = Color.White;
                else
                    dgvExams.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
            }
        }

        private static List<StudentWithExam> GenerateStudentWithExamsList(int groupID, int disciplineID)
        {
            List<Student> students;
            List<StudentExam> exams;
            List<StudentWithExam> studentsExams = null;
            Student student;


            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
                exams = GetStudentExams(groupID, disciplineID);
            }
            catch (Exception ex)
            {
                //NOTE: Not handled exception
                return studentsExams;
            }

            studentsExams = new List<StudentWithExam>();

            exams = (from stExams in exams
                     where stExams.isNotPassed
                     select stExams).ToList();

            foreach(var exam in exams)
            {
                student = (from st in students
                           where st.id == exam.id_of_student
                           select st).Single();

                studentsExams.Add(new StudentWithExam()
                {
                    examInfo = exam,
                    studentID = student.id,
                    studentName = student.name
                });
            }
            return studentsExams;
        }
        private static DataGridViewColumn[] CreateColumns(ref DataGridView dgv, List<StudentWithExam> studentsExams)
        {
            if (studentsExams.Count == 0)
                return null;

            DataGridViewColumn[] columns = new DataGridViewTextBoxColumn[7];
            columns[0] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "stID", HeaderText = "stid", ReadOnly = true, Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "name", HeaderText = "ФИО", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            columns[2] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "sum", HeaderText = "Всего получено", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[3] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "examID", HeaderText = "examid", ReadOnly = true, Visible = false };
            columns[4] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "examPoints", HeaderText = "Баллы за экзамен", AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[5] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "examGrade", HeaderText = "Оценка за экзамен", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[6] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "recGrade", HeaderText = "Рек. оценка", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };

            return columns;
        }
        private static List<StudentExam> GetStudentExams(int groupID, int disciplineID)
        {
            List<StudentExam> studentExams;
            try
            {
                studentExams = DataService.SelectStudentsExams(groupID, disciplineID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return studentExams;
        }
    }
}
