using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MainLib.ReportsFactory;
using MainLib.DBServices;
using MainLib.Session;
using System.Configuration;

namespace PointRaitingSystem
{
    public partial class usrCertReportGenForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private int groupID, disciplineID;
        private string path;


        public usrCertReportGenForm(int groupID, int disciplineID)
        {
            InitializeComponent();
            DataSetsInitializer(groupID, disciplineID);
            this.groupID = groupID;
            this.disciplineID = disciplineID;
            path = ConfigurationManager.AppSettings["reportFilePath"];
        }

        private void DataSetsInitializer(int groupID, int disciplineID)
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
