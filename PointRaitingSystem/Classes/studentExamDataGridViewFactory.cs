using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    class studentExamDataGridViewFactory
    {
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, int groupId, List<StudentExam> exams)
        {
            dgv.Columns.Clear();

            List<StudentWithExam> studentsExams = GenerateStudentWithExamsList(groupId, exams);
            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentsExams);
            if (columns == null)
                return;

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentsExams.Count);

            for(int i = 0; i < studentsExams.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = studentsExams[i].studentID;
                dgv.Rows[i].Cells[1].Value = studentsExams[i].studentName;
                dgv.Rows[i].Cells[2].Value = studentsExams[i].examInfo.GetMaxStudentScore();
                if ((double)dgv.Rows[i].Cells[2].Value < 50)
                    dgv.Rows[i].Cells[2].Style.BackColor = Color.IndianRed;
                dgv.Rows[i].Cells[3].Value = studentsExams[i].examInfo.id;
                dgv.Rows[i].Cells[4].Value = studentsExams[i].examInfo.points;
                dgv.Rows[i].Cells[5].Value = 2;
                dgv.Rows[i].Cells[6].Style.BackColor = Color.LightGreen;
                dgv.Rows[i].Cells[6].Value = 2;
            }
        }

        private static List<StudentWithExam> GenerateStudentWithExamsList(int groupID, List<StudentExam> exams)
        {
            List<Student> students;

            List<StudentWithExam> studentsExams = null;
            StudentExam studentExam;


            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
            }
            catch(Exception ex)
            {
                //NOTE: Not handled exception
                return studentsExams;
            }

            studentsExams = new List<StudentWithExam>();
            foreach (Student student in students)
            {
                studentExam = (StudentExam)(from stExam in exams
                                           where stExam.id_of_student == student.id
                                           select stExam).Single();

                studentsExams.Add(new StudentWithExam() {
                    examInfo = studentExam,
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
    }
}
