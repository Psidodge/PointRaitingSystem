using iTextSharp.text.pdf;
using MainLib.ReportsFactory.Reports;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;

namespace MainLib.ReportsFactory
{
    public enum ReportType { CERTIFICATION = 1, EXAM = 2, NONE = 0 }

    public static class ReportFactory
    {
        // certDate need to be default
        public static bool GenerateReport(ReportType reportType, string path, int groupID, int teacherID, int disciplineID, DateTime certDate)
        {
            IReport report = null;
            switch (reportType)
            {
                case ReportType.CERTIFICATION:
                    report = new CertificationReport();
                    break;
                case ReportType.EXAM:
                    report = new ExamReport();
                    break;
                case ReportType.NONE:

                    return false;
            }

            if (report == null)
                return false;

            return report.GenerateReport(path, groupID, disciplineID, teacherID, certDate);
        }   
    }
}