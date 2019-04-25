using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;

namespace MainLib.ReportsFactory.Reports
{
    public interface IReport
    {
        bool GenerateReport(string folderPath, uint groupID, uint disciplineID, uint teacherID, DateTime? certDate = null);
    }
}
