using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;

namespace PointRaitingSystem
{
    public static class reexamStudentCPsDataGridViewFactory
    {
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, out List<StudentsWithCP> studentsCPs, int groupId, int disciplineId, int[] studentsIDs = null)
        {
            dgv.Columns.Clear();

            int cpIter = 0;
            double sum = 0;

            if(studentsIDs == null)
                studentsCPs = GetStudentsCPs(groupId, disciplineId);
            else
                studentsCPs = GetStudentsCPs(groupId, disciplineId, studentsIDs);

            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentsCPs);

            if (columns == null)
                throw new NullReferenceException($"In  'studentCPsDataGridViewFactory'.'CreateStudentCPsDataGridView' object 'columns' = {columns == null}");

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentsCPs.Count);

            for (int i = 0; i < studentsCPs.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = studentsCPs[i].id;
                dgv.Rows[i].Cells[1].Value = studentsCPs[i].name;
                for (int j = 2; j < dgv.Columns.Count - 1; j += 2, cpIter++)
                {
                    dgv.Rows[i].Cells[j].Value = studentsCPs[i].studentCPs[cpIter].id;
                    dgv.Rows[i].Cells[j + 1].Value = studentsCPs[i].studentCPs[cpIter].points;
                    sum += studentsCPs[i].studentCPs[cpIter].points;
                }
                dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = sum;
                cpIter = 0;
                sum = 0;
            }
        }
        public static void CalculateSum(ref DataGridView dgv)
        {
            double sum = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1 && cell.ColumnIndex < dgv.Columns.Count - 1 &&
                        !cell.OwningColumn.Name.Contains("id") && !cell.OwningColumn.Name.Contains("certification") &&
                        !cell.OwningColumn.Name.Contains("grade") && !cell.OwningColumn.Name.Contains("sum"))
                    {
                        sum += Convert.ToDouble(cell.Value.ToString().Replace('.', ',')
                                                                     .Replace('/', ',')
                                                                     .Replace('б', ',')
                                                                     .Replace('ю', ',')
                                                                     .Replace('Ю', ','));
                    }
                }
                row.Cells["sum"].Value = sum;
                sum = 0;
            }
        }
        private static DataGridViewColumn[] CreateColumns(ref DataGridView dgv, List<StudentsWithCP> stCPs)
        {
            if (stCPs.Count == 0)
                return null;

            DataGridViewColumn[] columns = new DataGridViewTextBoxColumn[(stCPs[0].studentCPs.Count * 2) + 3];
            columns[0] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "id", HeaderText = "id", ReadOnly = true, Visible = false };
            columns[1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "Name", HeaderText = "ФИО", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells };
            int iter = 0, colIter = 2;
            foreach (StudentControlPoint row in stCPs[0].studentCPs)
            {
                columns[colIter] = new DataGridViewTextBoxColumn()
                {
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Name = string.Format("idOfCP{0}", iter),
                    HeaderText = string.Format("idOfCP {0}", iter),
                    ReadOnly = true,
                    Visible = false,
                };
                columns[++colIter] = new DataGridViewTextBoxColumn()
                {
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Name = string.Format("cpName{0}", iter),
                    HeaderText = string.Format("КТ {0}", iter + 1),
                    ReadOnly = true,
                    Width = 45
                };

                columns[colIter].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                colIter++;
                iter++;
            }
            columns[columns.Length - 1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "sum", HeaderText = "Всего", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            return columns;
        }
        private static List<StudentsWithCP> GetStudentsCPs(int groupId, int dId, int[] studentsIDs)
        {
            List<StudentsWithCP> studentsCPs = new List<StudentsWithCP>();
            List<Student> students = null;
            List<StudentControlPoint> pointsOfStudents = null;

            try
            {
                students = DataService.SelectStudentsByGroupId(groupId).Where(x => studentsIDs.Contains(x.id)).ToList();
                pointsOfStudents = DataService.SelectStudentControPointsGroupDisc(groupId, dId, Session.GetCurrentSession().ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (students == null || pointsOfStudents == null)
                throw new NullReferenceException($"In method 'studentCPsDataGridViewFactory'.'GetStudentsCPs' object 'students' = {students == null} or 'pointsOfStudents' = {pointsOfStudents == null}");

            foreach (Student student in students)
            {
                studentsCPs.Add(new StudentsWithCP()
                {
                    id = student.id,
                    name = student.name,
                    studentCPs = (from cp in pointsOfStudents
                                  where cp.id_of_student == student.id
                                  select cp).ToList()
                });

            }
            return studentsCPs;
        }
        private static List<StudentsWithCP> GetStudentsCPs(int groupId, int dId)
        {
            List<StudentsWithCP> studentsCPs = new List<StudentsWithCP>();
            List<Student> students = null;
            List<StudentControlPoint> pointsOfStudents = null;

            try
            {
                students = DataService.SelectStudentsByGroupId(groupId);
                pointsOfStudents = DataService.SelectStudentControPointsGroupDisc(groupId, dId, MainLib.Session.Session.GetCurrentSession().ID);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            if (students == null || pointsOfStudents == null)
                throw new NullReferenceException($"In method 'studentCPsDataGridViewFactory'.'GetStudentsCPs' object 'students' = {students == null} or 'pointsOfStudents' = {pointsOfStudents == null}");

            foreach (Student student in students)
            {
                studentsCPs.Add(new StudentsWithCP()
                {
                    id = student.id,
                    name = student.name,
                    studentCPs = (from cp in pointsOfStudents
                                  where cp.id_of_student == student.id
                                  select cp).ToList()
                });

            }
            return studentsCPs;
        }
    }
}
