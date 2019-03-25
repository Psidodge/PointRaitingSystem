using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.ReportsFactory.Reports;

namespace MainLib.ReportsFactory
{
    public abstract class ReportsFactory
    {
        private const string repotsFolderPath = ".\\Reports";

        public enum ReportType { Certification = 1, Exam = 2, NULL = 0 };



        public bool GenerateReport(ReportType type)
        {
            IReport report = null;

            switch (type)
            {
                case ReportType.Certification:
                    report = new CertificationReport();
                    break;
                case ReportType.Exam:
                    report = new ExamReport();
                    break;
                case ReportType.NULL:
                    throw new NullReferenceException("Type of report is null.");
            }

            if (report.GenerateReport(repotsFolderPath))
                return true;
            return false;
        }
    }
}
