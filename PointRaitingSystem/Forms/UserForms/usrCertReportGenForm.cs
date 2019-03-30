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

namespace PointRaitingSystem
{
    public partial class usrCertReportGenForm : Form
    {
        public usrCertReportGenForm(int groupID, int disciplineID)
        {
            InitializeComponent();
            DataSetsInitializer(groupID, disciplineID);
        }

        private void DataSetsInitializer(int groupID, int disciplineID)
        {
            try
            {
                List<StudentCertification> certifications = DataService.SelectStudentsCertifications(groupID, disciplineID);
            }
            catch
            {

            }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {

        }
    }
}
