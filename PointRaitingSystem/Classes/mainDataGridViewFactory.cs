using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;

namespace PointRaitingSystem
{
    //TODO: Здесь не отлавливаются исключения. Добавить
    // NOTE: Медленно работает, попробывать оптимизировать или нет
    public static class mainDataGridViewFactory
    {
        public static void CreateStudentCPsDataGridView(ref DataGridView dgv, uint groupId, uint disciplineId, out bool isReexamCommited)
        {
            dgv.Columns.Clear();
            isReexamCommited = false;
            int cpIter = 0; 
            double sum = 0;
            List<StudentExam> exams = null;
            StudentReexam tempReexam = null;
            List<StudentsWithCP> studentsCPs = GetStudentsCPs(groupId, disciplineId, out exams);

            if (isHavingNullPoints(ref studentsCPs))
                return;

            DataGridViewColumn[] columns = CreateColumns(ref dgv, studentsCPs);
            
            if (columns == null)
                throw new NullReferenceException($"In  'studentCPsDataGridViewFactory'.'CreateStudentCPsDataGridView' object 'columns' = {columns == null}");

            dgv.Columns.AddRange(columns);
            dgv.Rows.Add(studentsCPs.Count);

            if (exams.Count == 0)
                dgv.Columns["grade"].Visible = false;

            for (int i = 0; i < studentsCPs.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = studentsCPs[i].id;
                dgv.Rows[i].Cells[1].Value = studentsCPs[i].name;
                for (int j = 2; j < dgv.Columns.Count - 2; j+=2, cpIter++)
                {
                    dgv.Rows[i].Cells[j].Value = studentsCPs[i].studentCPs[cpIter].id;
                    dgv.Rows[i].Cells[j + 1].Value = studentsCPs[i].studentCPs[cpIter].points;
                    sum += studentsCPs[i].studentCPs[cpIter].points;
                }
                if (exams.Count != 0)
                {
                    if (exams[i].id_of_reexam != 0)
                    {
                        tempReexam = GetReexam(exams[i].id_of_reexam);
                        if (tempReexam.points == 0)
                        {
                            dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = "неуд.";
                            dgv.Rows[i].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.IndianRed;
                        }
                        else if(tempReexam.points != 0)
                        {
                            dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = $"{tempReexam.CountRecommendedGrade(studentsCPs[i].id, disciplineId)}*";
                            dgv.Rows[i].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.White;
                            isReexamCommited = true;
                        }
                    }
                    else if(exams[i].id_of_reexam == 0)
                    {
                        dgv.Rows[i].Cells[dgv.Columns.Count - 1].Value = exams[i].CountRecommendedGrade();
                    }
                    //dgv.Rows[i].Cells[dgv.Columns.Count - 1].Style.BackColor = Color.LightSeaGreen;
                }
                dgv.Rows[i].Cells[dgv.Columns.Count - 2].Value = sum;
                cpIter = 0;
                sum = 0;
            }
        }
        public static void InsertCertifications(ref DataGridView dgv, uint groupId, uint disciplineId, out int[] certificationIndexes, int rowIndex = 0, List<StudentCertification> studentCertifications = null, List<StudentControlPoint> studentsControlPoints = null)
        {
            List<StudentCertification> distinctStudentCertifications;

            if (studentCertifications == null && studentsControlPoints == null)
            {
                try
                {
                    studentCertifications = DataService.SelectStudentsCertifications(groupId, disciplineId);
                    studentsControlPoints = DataService.SelectStudentControPointsGroupDisc(groupId, disciplineId, Session.GetCurrentSession().ID);
                }
                catch (Exception)
                {
                    throw;
                }
            }

            if (studentsControlPoints.Count == 0)
            {
                certificationIndexes = null;
                return;
            }
            // indexes of certification
            distinctStudentCertifications = studentCertifications.GroupBy(x => x.id_of_prev_cp).Select(item => item.First()).ToList();

            if (distinctStudentCertifications.Count == 0)
            {
                certificationIndexes = null;
                return;
            }

            int amountOfCert = distinctStudentCertifications.Count(),
                certIter = 0;
            certificationIndexes = new int[amountOfCert];

            foreach(StudentCertification certification in distinctStudentCertifications)
            {
                uint idOfSCP = 0;
                try
                {
                    idOfSCP = (from scp in studentsControlPoints
                                   where scp.id_of_controlPoint == certification.id_of_prev_cp && scp.id_of_student == certification.id_of_student
                                   select scp.id).First();
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                /* (dgv.Columns.Count - 3); -3 - потому что, первые 2 это id, и ФИО + последняя Всего */
                for (int i = 0; i < (dgv.Columns.Count - 4) / 2; i++)
                {
                    if ((uint)dgv.Rows[rowIndex].Cells[string.Format("idOfCP{0}", i)].Value == idOfSCP)
                    {
                        certificationIndexes[certIter] = dgv.Columns[string.Format("idOfCP{0}", i)].Index + 2;

                        dgv.Columns.Insert(certificationIndexes[certIter],
                            new DataGridViewTextBoxColumn() {
                                SortMode = DataGridViewColumnSortMode.NotSortable,
                                Name = string.Format("certification{0}", certIter),
                                HeaderText = string.Format("Аттестация {0}", certIter + 1),
                                ReadOnly = true,
                                Visible = true,
                                Width = 105
                            });

                        dgv.Columns[certificationIndexes[certIter]].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    }
                }
                certIter++;
            }

            if (certificationIndexes.Contains(0))
                InsertCertifications(ref dgv, groupId, disciplineId, out certificationIndexes, ++rowIndex, studentCertifications, studentsControlPoints);
            FillStudentsCertificationsCells(ref dgv, ref studentCertifications, ref certificationIndexes);
        }
        public static void CalculateSum(ref DataGridView dgv)
        {
            double sum = 0;
            foreach(DataGridViewRow row in dgv.Rows)
            {
                foreach(DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex > 1 && cell.ColumnIndex < dgv.Columns.Count - 1 && 
                        !cell.OwningColumn.Name.Contains("id") && !cell.OwningColumn.Name.Contains("certification") && 
                        !cell.OwningColumn.Name.Contains("grade") && !cell.OwningColumn.Name.Contains("sum"))
                    {
                        sum += Convert.ToDouble(cell.Value.ToString().Replace('.',',')
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
        private static void FillStudentsCertificationsCells(ref DataGridView dgv, ref List<StudentCertification> certifications, ref int[] columnIndexes)
        {
            List<StudentCertification> tempCertifications = null;
            uint stID;

            foreach(DataGridViewRow row in dgv.Rows)
            {
                stID = (uint)row.Cells[0].Value;
                tempCertifications = certifications.Where(x => x.id_of_student == stID).ToList();

                if(tempCertifications.Count == columnIndexes.Length)
                {
                    for (int i = 0; i < columnIndexes.Length; i++)
                    {
                        row.Cells[columnIndexes[i]].Value = tempCertifications[i].grade;
                        row.Cells[columnIndexes[i]].Style.BackColor = Color.LightGreen;
                    }
                }
                else if(tempCertifications.Count == 0 && columnIndexes.Length != 0)
                {
                    row.Cells[columnIndexes.Max()].Value = "-";
                    row.Cells[columnIndexes.Max()].Style.BackColor = Color.LightGreen;
                }



                //if (tempCertifications.Count == columnIndexes.Length)
                //{
                //    for(int i = 0; i < columnIndexes.Length; i++)
                //    {
                //        row.Cells[columnIndexes[i]].Value = tempCertifications[i].grade;
                //        row.Cells[columnIndexes[i]].Style.BackColor = Color.LightGreen;
                //    }
                //}

                //if (tempCertifications.Count == 1 && columnIndexes.Length == 2)
                //{
                //    if (columnIndexes.Length == 1)
                //    {
                //        row.Cells[columnIndexes[0]].Value = "-";
                //        row.Cells[columnIndexes[0]].Style.BackColor = Color.LightGreen;
                //    }
                //    else
                //    {
                //        row.Cells[columnIndexes.Min()].Value = "-";
                //        row.Cells[columnIndexes.Min()].Style.BackColor = Color.LightGreen;
                //        row.Cells[columnIndexes.Max()].Value = tempCertifications[0].grade;
                //        row.Cells[columnIndexes.Max()].Style.BackColor = Color.LightGreen;
                //    }
                //}
            }

            //foreach (DataGridViewRow row in dgv.Rows)
            //{
            //    foreach (int colIndex in columnIndexes)
            //    {
            //        row.Cells[colIndex].Style.BackColor = Color.LightGreen;
            //        if (certifications[certIter].id_of_student == (int)row.Cells[0].Value)
            //            row.Cells[colIndex].Value = certifications[certIter].grade;
            //        else
            //        {
            //            row.Cells[colIndex].Value = "-";
            //            certIter--;
            //        }
            //        certIter++;
            //    }
            //}
        }
        private static DataGridViewColumn[] CreateColumns(ref DataGridView dgv, List<StudentsWithCP> stCPs)
        {
            if (stCPs.Count == 0)
                return null;

            DataGridViewColumn[] columns = new DataGridViewTextBoxColumn[(stCPs[0].studentCPs.Count * 2) + 4];
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
            columns[columns.Length - 2] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "sum", HeaderText = "Всего", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            columns[columns.Length - 1] = new DataGridViewTextBoxColumn() { SortMode = DataGridViewColumnSortMode.NotSortable, Name = "grade", HeaderText = "Итоговая оценка", ReadOnly = true, AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader };
            return columns;
        }
        private static List<StudentsWithCP> GetStudentsCPs(uint groupId, uint dId, out List<StudentExam> exams)
        {
            List<StudentsWithCP> studentsCPs = new List<StudentsWithCP>();
            List<Student> students = null;
            List<StudentControlPoint> pointsOfStudents = null;
            exams = null;

            try
            {
                students = DataService.SelectStudentsByGroupId(groupId);
                pointsOfStudents = DataService.SelectStudentControPointsGroupDisc(groupId, dId, Session.GetCurrentSession().ID);
                exams = DataService.SelectStudentsExams(groupId, dId);
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
        private static StudentReexam GetReexam(uint reexamID)
        {
            try
            {
                return DataService.SelectReexamsByID(reexamID);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private static bool isHavingNullPoints(ref List<StudentsWithCP> studentsCPs)
        {
            List<StudentsWithCP> tempListOfStudentsWithNulls = new List<StudentsWithCP>();

            foreach(StudentsWithCP student in studentsCPs)
            {
                if (student.studentCPs.Count == 0)
                    tempListOfStudentsWithNulls.Add(student);
            }

            if (tempListOfStudentsWithNulls.Count == 0 || studentsCPs.Count == tempListOfStudentsWithNulls.Count)
                return false;

            if (MessageBox.Show($"У {tempListOfStudentsWithNulls.Count} студентов отсутствуют КТ. Сгенерировать для них КТ?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return true;

            List<StudentControlPoint> studentControlPoints = studentsCPs.Except(tempListOfStudentsWithNulls).ToList()[0].studentCPs;

            foreach(StudentsWithCP st in tempListOfStudentsWithNulls)
            {
                try
                {
                    foreach(StudentControlPoint stCP in studentControlPoints)
                    {
                        //st.studentCPs.Add
                        var stCPToIns = new ControlPointsOfStudents
                        {
                            id_of_controlPoint = stCP.id_of_controlPoint,
                            id_of_student = st.id,
                            points = 0
                        };

                        st.studentCPs.Add(stCPToIns.ConvertToStudentControlPoint());
                        DataService.InsertIntoStudentCPTable(stCPToIns);
                    }
                }
                catch(Exception ex)
                {
                    NLog.LogManager.GetCurrentClassLogger().Error(ex);
                    return true;
                }
                studentsCPs[studentsCPs.IndexOf(st)].studentCPs = st.studentCPs;
            }
            return false;
        }
    }
}
