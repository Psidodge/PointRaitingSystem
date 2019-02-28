using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MainLib.Parsing;

namespace PointRaitingSystem
{
    public partial class admParserPreviweForm : Form
    {
        private List<ParsedData> orgParsedDatas;

        public admParserPreviweForm(ref List<ParsedData> data)
        {
            InitializeComponent();
            orgParsedDatas = data;
            InitializeDataSets();
        }

        private void admParserPreviweForm_Load(object sender, EventArgs e)
        {
        }
        private void InitializeDataSets()
        {
            List<ParsedData> cpyParsedData = orgParsedDatas;

            //HACK: не придумал ничего лучше этого
            var @switch = new Dictionary<Type, Action>
            {
                { typeof(ParsedDiscipline), () => DataSetInitializer<ParsedDiscipline>.dgvDataSetInitializer(ref dgvPreviewData, cpyParsedData.OfType<ParsedDiscipline>().ToList()) },
                { typeof(ParsedStudent), () => DataSetInitializer<ParsedStudent>.dgvDataSetInitializer(ref dgvPreviewData, cpyParsedData.OfType<ParsedStudent>().ToList()) },
                { typeof(ParsedTeacher), () => DataSetInitializer<ParsedTeacher>.dgvDataSetInitializer(ref dgvPreviewData, cpyParsedData.OfType<ParsedTeacher>().ToList()) },
            };

            dgvPreviewData.AutoGenerateColumns = true;
            @switch[cpyParsedData[0].GetTypeOfData()]();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
