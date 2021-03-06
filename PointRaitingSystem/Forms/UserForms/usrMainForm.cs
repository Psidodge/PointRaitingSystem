﻿//#undef DEBUG

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MainLib.DBServices;
using MainLib.Session;
using MainLib.ReportsFactory;
using System.Configuration;
using System.Drawing;

namespace PointRaitingSystem
{
    public partial class usrMainForm : Form
    {
        public usrMainForm() 
        {
            InitializeComponent();
#if DEBUG
            tsmDeb.Visible = true;
#endif
            InitializeDataSets();
            LoadFontSettings();
            tsslCurrentDate.Text = DateTime.Now.ToShortDateString();
        }

        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string selectedCPDescription = null;
        public uint selectedCPID;
        private int cbGroupsPrevIndex = 0;
        private int[] certificationIndexes = null;
        private bool isCellsHiden = false,
                     isReexamCommited = false;
       
        private void LoadFontSettings()
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            this.Font = (Font)converter.ConvertFromString(ConfigurationManager.AppSettings["fontSettings"]);
        }

        private void cbGroups_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cbDiscipline.Text = string.Empty;
            cbDiscipline.SelectedIndex = -1;
            try
            {
                cbDiscipline.DataSource = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (uint)cbGroups.SelectedValue);

                if (cbDiscipline.Items.Count == 0)
                {
                    dgvStudents.Rows.Clear();
                    dgvStudents.Columns.Clear();
                    return;
                }
                dgvRefresh();
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void cbDiscipline_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                dgvRefresh();
                //mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
                FillControlPointInfo();
                isCellsHiden = false;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCreateCP_Click(object sender, EventArgs e)
        {
            usrCPAddForm form = new usrCPAddForm((uint)cbGroups.SelectedValue, cbDiscipline.SelectedValue);
            form.ShowDialog();
            try
            {
                dgvRefresh();
                //mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out isReexamCommited);
                //mainDataGridViewFactory.InsertCertifications(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out certificationIndexes);
                //BlockCreation(DataService.GetSumOfPointsUsed((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue));
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnShowCP_Click(object sender, EventArgs e)
        {
            usrCPShowForm form2 = new usrCPShowForm((Discipline)cbDiscipline.SelectedItem);
            form2.Show();
        }
        private void btnAddExam_Click(object sender, EventArgs e)
        {
            usrReExamFrom form = new usrReExamFrom((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, ExamType.Exam);
            form.ShowDialog();

            if (form.IsCommited)
            {
                btnCertification.Enabled = false;
                btnAddExam.Enabled = false;
                btnReexam.Enabled = true;
            }
            dgvRefresh();
        }
        private void btnReExam_Click(object sender, EventArgs e)
        {
            usrReExamFrom form = new usrReExamFrom((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, ExamType.Reexam);
            form.ShowDialog();
            dgvRefresh();
        }
        private void cbGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillControlPointInfo();
            isCellsHiden = false;
            cbGroupsPrevIndex = cbGroups.SelectedIndex;
        }

        private void dgvRefresh()
        {
            try
            {
                mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out isReexamCommited);
                mainDataGridViewFactory.InsertCertifications(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out certificationIndexes);
                BlockCreation(DataService.GetSumOfPointsUsed((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue));
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void InitializeDataSets()
        {
            double pointsUsed = 0d;
            try
            {
                //cbGroup
                List<Group> groups = DataService.SelectGroupsByTeacherId(Session.GetCurrentSession().ID);
                DataSetInitializer.ComboBoxDataSetInitializer<Group>(ref cbGroups, groups, "id", "name");
                //cbDiscipline
                List<Discipline> disciplines = DataService.SelectDisciplinesByTeacherIdAndGroupId(Session.GetCurrentSession().ID, (uint)cbGroups.SelectedValue);
                DataSetInitializer.ComboBoxDataSetInitializer<Discipline>(ref cbDiscipline, disciplines, "id", "full_name");
                //dgvStudents dataset
                mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out isReexamCommited);
                //insert certification
                if (dgvStudents.Columns.Count != 0)
                    mainDataGridViewFactory.InsertCertifications(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out certificationIndexes);
                pointsUsed = DataService.GetSumOfPointsUsed((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                //MessageBox.Show("Произошла ошибка при инициализации набора данных.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //tsslTeacherName
            tsslTeacherName.Text = Session.GetCurrentSession().UserName;
            BlockCreation(pointsUsed);
        }
        private void BlockCreation(double pointsUsed)
        {
            btnCertification.Enabled = true;
            btnCreateCP.Enabled = true;
            btnPickCPs.Enabled = true;
            btnAddExam.Enabled = true;

            if (pointsUsed == 80d)
            {
                btnCreateCP.Enabled = false;
                btnPickCPs.Enabled = false;
            }

            if (certificationIndexes != null)
            {
                if (certificationIndexes.Length == 2)
                    btnCertification.Enabled = false;

                if (certificationIndexes.Length != 2)
                    btnAddExam.Enabled = false;

                btnReexam.Enabled = false;
            }
            else
            {
                btnReexam.Enabled = false;
                btnAddExam.Enabled = false;
            }

            if (dgvStudents.Columns.Count == 0)
                return;

            if (dgvStudents.Columns[dgvStudents.Columns.Count - 1].Visible)
            {
                btnCreateCP.Enabled = false;
                btnPickCPs.Enabled = false;
                btnAddExam.Enabled = false;
                btnReexam.Enabled = !isReexamCommited;
            }
        }
        private void FillControlPointInfo(bool isVisible = false)
        {
            gbCPInfo.Visible = isVisible;
            if (!isVisible)
                return;

            ControlPointInfo cpInfo = null;
            try
            {
                uint id = (uint)dgvStudents.CurrentRow.Cells[dgvStudents.SelectedColumns[0].Index - 1].Value;
                cpInfo = DataService.SelectControlPointInfo(id);
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
            lblAuthor.Text = cpInfo.name;
            lblDiscipline.Text = cpInfo.discipline_name;
            lblWeight.Text = cpInfo.weight.ToString();
            txtDescription.Text = cpInfo.description;

            selectedCPDescription = cpInfo.description;
            selectedCPID = cpInfo.id;
        }
        private void FillCertificationInfo(bool isVisible = false, int certIndex = -1)
        {
            gbCertificationInfo.Visible = isVisible;
            if (!isVisible || certIndex == -1)
                return;

            StudentCertification studentCertification = null;
            try
            {
                // NOTE: BUG HERE
                uint studentID = (uint)dgvStudents.CurrentRow.Cells[0].Value;
                var stCeritifications = DataService.SelectStudentCertifications((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, studentID);
                studentCertification = stCeritifications[certIndex];
                lblCertCreator.Text = DataService.SelectTeacherById(studentCertification.id_of_user).Name.ToString();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            lblMaxPointsSum.Text = studentCertification.GetMaxSumOfPointsForCurCP().ToString();
            lblDate.Text = studentCertification.date.ToShortDateString();
        }

        private void bindingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usrSettingsForm usrSettingsForm = new usrSettingsForm();
            usrSettingsForm.ShowDialog();
            InitializeDataSets();
        }
        private void dgvStudents_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            double pointsToIns = Convert.ToDouble(dgvStudents.CurrentCell.Value.ToString().Replace('.', ',')
                                                                                          .Replace('/', ',')
                                                                                          .Replace('б', ',')
                                                                                          .Replace('ю', ',')
                                                                                          .Replace('Ю', ','));
            dgvStudents.CurrentCell.Value = pointsToIns;
            uint id = Convert.ToUInt32(dgvStudents.CurrentRow.Cells[e.ColumnIndex - 1].Value);
            
            try
            {
                uint idOfCP = Convert.ToUInt32(dgvStudents.CurrentRow.Cells[dgvStudents.CurrentCell.ColumnIndex - 1].Value);
                ControlPointInfo cpInfo = DataService.SelectControlPointInfo(idOfCP);

                if (pointsToIns < 0 || pointsToIns > cpInfo.weight)
                { 
                    MessageBox.Show("Введеные баллы превышаеют вес КТ.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvStudents.CurrentCell.Value = 0;
                    return;
                }
                DataService.UpdateStudentCP(pointsToIns, id);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при обновлении баллов студента.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvStudents.CurrentCell.Value = 0;
                return;
            }
        }
        private void dgvStudents_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int selectedColIndex = dgvStudents.SelectedColumns[0].Index;
            try
            {
                if (selectedColIndex <= 1 || selectedColIndex >= dgvStudents.Columns.Count - 2)
                {
                    FillControlPointInfo();
                    isCellsHiden = false;
                    return;
                }

                if(certificationIndexes != null)
                    for (int i = 0; i < certificationIndexes.Length; i++)
                    {
                        if (selectedColIndex == certificationIndexes[i])
                        {
                            FillControlPointInfo();
                            FillCertificationInfo(true, i);
                            isCellsHiden = false;
                            return;
                        }
                    }


                if (!isCellsHiden)
                {
                    foreach (DataGridViewColumn column in dgvStudents.Columns)
                    {
                        if (column.Index > 1 && column.Index < dgvStudents.Columns.Count - 1 && selectedColIndex > 1 && selectedColIndex < dgvStudents.Columns.Count - 1)
                        {
                            if(column.Index != selectedColIndex - 1 && column.Index != selectedColIndex)
                                column.Visible = false;
                            if (column.Index == selectedColIndex && !dgvStudents.Columns[dgvStudents.Columns.Count - 1].Visible)
                                column.ReadOnly = false;
                        }
                    }
                    isCellsHiden = true;
                    FillCertificationInfo();
                    FillControlPointInfo(true);
                }
                else
                {
                    foreach (DataGridViewColumn column in dgvStudents.Columns)
                    {
                        if (!column.Name.Contains("id") && column.Index != dgvStudents.Columns.Count - 1)
                        {
                            column.Visible = true;
                            column.ReadOnly = true;
                        }
                    }
                    mainDataGridViewFactory.CalculateSum(ref dgvStudents);
                    isCellsHiden = false;
                    FillControlPointInfo();
                }
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Произошла ошибка при перерисовки интерфейса.", "Произошла ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCertification_Click(object sender, EventArgs e)
        {
            usrCertificationAddForm form = new usrCertificationAddForm(((Group)cbGroups.SelectedItem).name, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
            form.ShowDialog();
            dgvRefresh();
            //mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
            //mainDataGridViewFactory.InsertCertifications(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out certificationIndexes);

            //if (certificationIndexes == null)
            //    return;

            //if (certificationIndexes.Length == 2)
            //{
            //    btnAddExam.Enabled = true;
            //    btnCertification.Enabled = false;
            //}
        }
        private void tsmiCertification_Click(object sender, EventArgs e)
        {
            usrCertReportGenForm form = new usrCertReportGenForm((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
            form.ShowDialog();
        }
        private void tsmiExam_Click(object sender, EventArgs e)
        {
            string path = ConfigurationManager.AppSettings["reportFilePath"];
            bool result = ReportFactory.GenerateReport(ReportType.EXAM, path, (uint)cbGroups.SelectedValue, Session.GetCurrentSession().ID, (uint)cbDiscipline.SelectedValue);
            if (result)
                MessageBox.Show("Отчет успешно сформирован", "Вот", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Отчет не сформирован", "Вот", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private void tsmiPickReportFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();

            if (folderBrowser.ShowDialog() == DialogResult.Cancel)
                return;

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["reportFilePath"].Value = folderBrowser.SelectedPath;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void btnPickCPs_Click(object sender, EventArgs e)
        {
            try
            { 
                usrTemplateList form = new usrTemplateList((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
                form.ShowDialog();
                dgvRefresh();
                //mainDataGridViewFactory.CreateStudentCPsDataGridView(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue);
                //mainDataGridViewFactory.InsertCertifications(ref dgvStudents, (uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue, out certificationIndexes);
                //BlockCreation(DataService.GetSumOfPointsUsed((uint)cbGroups.SelectedValue, (uint)cbDiscipline.SelectedValue));
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
}
        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if(txtDescription.Text != selectedCPDescription)
            {
                try
                {
                    DataService.UpdateCPDescription(txtDescription.Text, selectedCPID);
                }
                catch(Exception ex)
                {
                    logger.Error(ex);
                }
            }
        }

        //NOTE: не забдь удалить
        private void NullControlsDataSources()
        {
            cbGroups.DataSource = null;
            cbDiscipline.DataSource = null;
            dgvStudents.Columns.Clear();
            dgvStudents.DataSource = null;
        }
        private void tsmiAdm_Click(object sender, EventArgs e)
        {
#if DEBUG
            admMainForm form = new admMainForm();
            form.Show();
#endif
        }
        private void tsmiFontSetting_Click(object sender, EventArgs e)
        {
            fontDialog.ShowDialog();
            this.Font = fontDialog.Font;

            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));

            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings["fontSettings"].Value = converter.ConvertToString(this.Font);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
        private void tscbDebUserList_TextChanged(object sender, EventArgs e)
        {
#if DEBUG
            Session.CreateSessionInstance(tscbDebUserList.SelectedItem.ToString());
            NullControlsDataSources();
            InitializeDataSets();
#endif
        }
    }
}
