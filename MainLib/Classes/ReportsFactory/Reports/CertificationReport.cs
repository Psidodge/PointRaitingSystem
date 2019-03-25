using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.ReportsFactory.Reports
{
    class CertificationReport : IReport
    {
        public bool GenerateReport(string folderPath)// List<StudentCertification> ds)
        {

            //string filePath = Path.Combine(folderPath, string.Format("{0}_Аттестация_{1}_{2}", ds[0].date, ));
            return false;
        }
    }
}
