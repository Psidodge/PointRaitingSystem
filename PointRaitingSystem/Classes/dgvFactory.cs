using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainLib.DBServices;

namespace PointRaitingSystem
{
    //TODO: Здесь не отлавливаются исключения. Добавить
    public static class studentCPsDataGridViewFactory
    {
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, int groupId, int disciplineId)
        {
            dgv.Columns.Clear();
            int cpIter = 0, 
                sum = 0;
            List<StudentsWithCP> studentsCPs = GetStudentsCPs(groupId, disciplineId);
            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentsCPs);

            if(columns == null)
                return;

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentsCPs.Count - 1);

            for (int i = 0; i < studentsCPs.Count - 1; i++)
            {
                dgv.Rows[i].Cells[0].Value = studentsCPs[i].id;
                dgv.Rows[i].Cells[1].Value = studentsCPs[i].name;
                for (int j = 2; j < dgv.Columns.Count - 1; j+=2, cpIter++)
                {
                    dgv.Rows[i].Cells[j].Value = studentsCPs[i].studentCPs[cpIter].id;
                    dgv.Rows[i].Cells[j + 1].Value = studentsCPs[i].studentCPs[cpIter].points;
                    sum += studentsCPs[i].studentCPs[cpIter].points;
                }
                dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = sum;
                cpIter = sum = 0;
            }
        }
        public static void CalculateSum(ref DataGridView dgv)
        {
            int sum = 0;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1 && cell.ColumnIndex < dgv.Columns.Count - 1 && !cell.OwningColumn.Name.Contains("id"))
                    {
                        sum += Convert.ToInt32(cell.Value);
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
                    Visible = false
                };
                columns[++colIter] = new DataGridViewTextBoxColumn()
                {
                    SortMode = DataGridViewColumnSortMode.NotSortable,
                    Name = string.Format("cpName{0}", iter),
                    HeaderText = string.Format("КТ {0}", iter + 1),
                    ReadOnly = true
                };
                colIter++;
                iter++;
            }
            columns[columns.Length - 1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "sum", HeaderText = "Всего", ReadOnly = true };
            return columns;
        }
        private static List<StudentsWithCP> GetStudentsCPs(int groupId, int dId)
        {
            List<StudentsWithCP> studentsCPs = new List<StudentsWithCP>();

            List<Student> students = DataService.SelectStudentsByGroupId(groupId);
            List<StudentControlPoint> pointsOfStudents = DataService.SelectStudentControPointsGroupDisc(groupId, dId);
            foreach(Student student in students)
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
