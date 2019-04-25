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
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, out uint[] studentsIDs, out List<StudentWithReexam> studentWithReexams, uint groupId, uint disciplineID)
        {
            studentsIDs = null;
            dgv.Columns.Clear();

            studentWithReexams = GenerateStudentWithExamsList(groupId, disciplineID);
            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentWithReexams.Count);
            if (columns == null)
                return;

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentWithReexams.Count);

            studentsIDs = new uint[studentWithReexams.Count];

            for (int i = 0; i < studentWithReexams.Count; i++)
            {
                studentsIDs[i] = studentWithReexams[i].studentID;
                dgv.Rows[i].Cells[0].Value = studentWithReexams[i].studentID;
                dgv.Rows[i].Cells[1].Value = studentWithReexams[i].studentName;
                dgv.Rows[i].Cells[2].Value = studentWithReexams[i].examInfo.GetMaxStudentScore();
                if ((double)dgv.Rows[i].Cells[2].Value < 50)
                    dgv.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
                dgv.Rows[i].Cells[3].Value = studentWithReexams[i].examInfo.id;
                dgv.Rows[i].Cells[4].Value = studentWithReexams[i].examInfo.points;
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
        private static List<StudentWithReexam> GenerateStudentWithExamsList(uint groupID, uint disciplineID)
        {
            List<Student> students;
            List<StudentExam> exams;
            List<StudentWithReexam> studentsReexams = null;
            Student student;


            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
                exams = GetStudentExams(groupID, disciplineID);
            }
            catch (Exception ex)
            {
                //NOTE: Not handled exception
                return studentsReexams;
            }

            studentsReexams = new List<StudentWithReexam>();

            exams = (from stExams in exams
                     where stExams.id_of_reexam != 0
                     select stExams).ToList();

            foreach(var exam in exams)
            {
                student = (from st in students
                           where st.id == exam.id_of_student
                           select st).Single();

                studentsReexams.Add(new StudentWithReexam()
                {
                    examInfo = exam,
                    reexamInfo = DataService.SelectReexamsByID(exam.id_of_reexam),
                    studentID = student.id,
                    studentName = student.name
                });
                studentsReexams[studentsReexams.Count - 1].reexamInfo.date = DateTime.Now.Date;
            }
            return studentsReexams;
        }
        private static DataGridViewColumn[] CreateColumns(ref DataGridView dgv, int amountOfStudents)
        {
            if (amountOfStudents == 0)
                return null;

            DataGridViewColumn[] columns = new DataGridViewTextBoxColumn[7];
            columns[0] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "stID", HeaderText = "stid", ReadOnly = true, Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "name", HeaderText = "ФИО", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill };
            columns[2] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "sum", HeaderText = "Всего получено", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[3] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "reexamID", HeaderText = "examid", ReadOnly = true, Visible = false };
            columns[4] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "reexamPoints", HeaderText = "Баллы за переэкзаменовку", AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[5] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "reexamGrade", HeaderText = "Оценка за переэкзаменовку", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[6] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "recGrade", HeaderText = "Рек. оценка", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };

            return columns;
        }
        private static List<StudentExam> GetStudentExams(uint groupID, uint disciplineID)
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
