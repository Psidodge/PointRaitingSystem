using MainLib.DBServices;
using MainLib.Parsing;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public partial class admParserForm : Form
    {
        private DataType selectedType = DataType.None;
        private List<ParserEntity> parsedData;
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private string filePath;



        public admParserForm()
        {
            InitializeComponent();
        }
        private void admParserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
        }
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedType = (DataType)cbType.SelectedIndex;
        }
        private void openFileDialogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            tsslInfo.Text = openFileDialog.FileName;

            try
            {
                filePath = openFileDialog.FileName;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Error occurred! See log for more details."); 
            }

        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            if (filePath == null)
            {
                tsslInfo.Text = "Файл не выбран.";
                return;
            }

            try
            {
                switch (selectedType)
                {
                    case DataType.None:
                        return;
                    case DataType.Disciplines:
                        ExcelParser.ParseDisciplines(out parsedData, filePath);
                        break;
                    case DataType.Students:
                        ExcelParser.ParseStudents(out parsedData, filePath);
                        break;
                    case DataType.Teachers:
                        ExcelParser.ParseTeachers(out parsedData, filePath);
                        break;

                }
                tsslInfo.Text = "Файл прочитан.";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if(parsedData == null || parsedData.Count == 0)
            {
                tsslInfo.Text = "Данные не были выгружены.";
                return;
            }
            admParserPreviweForm form = new admParserPreviweForm(ref parsedData);
            form.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (parsedData == null || parsedData.Count == 0)
            {
                tsslInfo.Text = "Данные не были выгружены.";
            }

            try
            {
                FillDataBase.Fill(selectedType, parsedData);
                tsslInfo.Text = "Сохранено.";
                this.Close();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                tsslInfo.Text = "Данные не сохранены.";
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
                return;

            tsslInfo.Text = openFileDialog.FileName;

            try
            {
                filePath = openFileDialog.FileName;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Error occurred! See log for more details.");
            }

        }
    }
}
