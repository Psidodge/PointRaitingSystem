using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainLib.Parsing;

namespace PointRaitingSystem
{
    public partial class admParserPreviweForm : Form
    {
        private List<ParserEntity> parsedDataList;

        public admParserPreviweForm(ref List<ParserEntity> data)
        {
            InitializeComponent();
            parsedDataList = data;
            InitializeDataSets();
        }

        private void admParserPreviweForm_Load(object sender, EventArgs e)
        {
        }
        private void InitializeDataSets()
        {
            List<ParserEntity> cpyParsedData = parsedDataList;

            var @switch = new Dictionary<Type, Action>
            {
                { typeof(ParsedDiscipline), () => DataSetInitializer.dgvDataSetInitializer<ParsedDiscipline>(ref dgvPreviewData, cpyParsedData.OfType<ParsedDiscipline>().ToList()) },
                { typeof(ParsedStudent), () => DataSetInitializer.dgvDataSetInitializer<ParsedStudent>(ref dgvPreviewData, cpyParsedData.OfType<ParsedStudent>().ToList()) },
                { typeof(ParsedTeacher), () => DataSetInitializer.dgvDataSetInitializer<ParsedTeacher>(ref dgvPreviewData, cpyParsedData.OfType<ParsedTeacher>().ToList()) },
            };

            dgvPreviewData.AutoGenerateColumns = true;
            @switch[cpyParsedData[0].GetTypeOfData()]();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvPreviewData_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            object[] parameters = new object[dgvPreviewData.Columns.Count];
            int paramIter = 0;

            foreach(DataGridViewColumn column in dgvPreviewData.Columns)
            {
                parameters[paramIter] = dgvPreviewData.CurrentRow.Cells[column.Index].Value;
            }

            parsedDataList[e.RowIndex].ChangeObject(parameters);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
