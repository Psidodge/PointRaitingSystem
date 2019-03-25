using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainLib.ReportsFactory.Reports
{
    public interface IReport
    {
        bool GenerateReport(string folderPath);
    }
}
