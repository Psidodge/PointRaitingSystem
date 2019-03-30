using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.ReportsFactory.Reports
{
    class ExamReport : IReport
    {

        public bool GenerateReport<T>(string folderPath, ref List<T> ds) where T : DBEntity
        {
            return false;
        }
    }
}
