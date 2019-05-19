using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MainLib.ReportsFactory;
using MainLib.DBServices;
using MainLib.Session;
using System.Configuration;
using System.Drawing;

namespace PointRaitingSystem
{
    public partial class usrCertReportGenForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private uint groupID, disciplineID;
        private string path;


        public usrCertReportGenForm(uint groupID, uint disciplineID)
        {
            InitializeComponent();
            DataSetsInitializer(groupID, disciplineID);
            this.groupID = groupID;
            this.disciplineID = disciplineID;
            path = ConfigurationManager.AppSettings["reportFilePath"];
            LoadFontSettings();
        }

        private void LoadFontSettings()
        {
            System.ComponentModel.TypeConverter converter = System.ComponentModel.TypeDescriptor.GetConverter(typeof(Font));
            this.Font = (Font)converter.ConvertFromString(ConfigurationManager.AppSettings["fontSettings"]);
        }

        private void DataSetsInitializer(uint groupID, uint disciplineID)
        {
            try
            {
                List<StudentCertification> certifications = DataService.SelectStudentsCertifications(groupID, disciplineID).GroupBy(d => d.date).Select(c => c.First()).ToList();
                DataSetInitializer.lbDataSetInitialize<StudentCertification>(ref lbListOfCerts, certifications, "date", "date");
            }
            catch(Exception ex)
            {
                logger.Error(ex);
            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "";
            try
            {
                ReportFactory.GenerateReport(ReportType.CERTIFICATION, path, groupID, Session.GetCurrentSession().ID, disciplineID, (DateTime)lbListOfCerts.SelectedValue);
                lblStatus.Text = "Отчет сформирован успешно.";
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                lblStatus.Text = "Не удалось сформировать отчет.";
            }
        }
    }
}
