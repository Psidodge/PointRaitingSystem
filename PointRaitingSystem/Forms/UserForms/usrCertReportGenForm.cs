using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MainLib.ReportsFactory;
using MainLib.DBServices;
using MainLib.Session;

namespace PointRaitingSystem
{
    public partial class usrCertReportGenForm : Form
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();
        private int groupID, disciplineID;


        public usrCertReportGenForm(int groupID, int disciplineID)
        {
            InitializeComponent();
            DataSetsInitializer(groupID, disciplineID);
            this.groupID = groupID;
            this.disciplineID = disciplineID;
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
            try
            {
                ReportFactory.GenerateReport(ReportType.CERTIFICATION, "\\", groupID, Session.GetCurrentSession().ID, disciplineID, (DateTime)lbListOfCerts.SelectedValue);
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
