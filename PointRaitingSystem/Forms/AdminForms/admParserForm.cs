using MainLib.DBServices;
using MainLib.Parsing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PointRaitingSystem
{
    public enum DataType { None = -1, Disciplines = 0, Groups = 1, Students = 2, Teachers = 3 };


    public partial class admParserForm : Form
    {
        private DataType selectedType = DataType.None;
        private List<DBTable> parsedData;
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

            tsslCurrentFile.Text = openFileDialog.FileName;

            try
            {
                filePath = openFileDialog.FileName;
            }
            catch(Exception ex)
            {
                logger.Error(ex);
                MessageBox.Show("Error occurred! See log for more details."); //NOTE: write normal error msg here
            }

        }
        private void btnParse_Click(object sender, EventArgs e)
        {
            try
            {
                switch (selectedType)
                {
                    case DataType.None:
                        return;
                    case DataType.Disciplines:
                        ExcelParser.ParseDisciplines(out parsedData, filePath);
                        break;
                    case DataType.Groups:
                        ExcelParser.ParseGroups(out parsedData, filePath);
                        break;
                    case DataType.Students:
                        ExcelParser.ParseStudents(out parsedData, filePath);
                        break;
                    case DataType.Teachers:

                        break;

                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }
    }
}
