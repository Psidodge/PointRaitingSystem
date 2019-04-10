using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using MainLib.DBServices;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MainLib.ReportsFactory.Reports
{
    public class ExamReport : IReport
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private List<StudentExam> exams;
        private List<Student> students;
        private UserInfo userInfo;
        private Discipline discipline;
        private Group group;

        private BaseFont bFont = BaseFont.CreateFont(@"resources\tnr.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

        public bool GenerateReport(string folderPath, int groupID, int disciplineID, int teacherID, DateTime? date = null)
        {

            if (!InitializeReportData(groupID, disciplineID, teacherID))
                return false;

            Document doc = new Document(PageSize.A4);
            PdfPTable pTable = null;

            var output = new FileStream($"{folderPath}\\Экзамен_{group.name}_{discipline.name}_{DateTime.Now.ToShortDateString()}.pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Open();
            GenerateReportHeader(ref doc);
            GenerateReportTableHeaders(ref doc, out pTable);
            GenerateReportColumns(ref doc, ref pTable);
            doc.Close();

            return true;
        }
        private void GenerateReportHeader(ref Document doc)
        {
            Font font = new Font(bFont, 15, Font.NORMAL, BaseColor.BLACK);

            Paragraph par = new Paragraph(string.Format("Отчет по проведенному экзамену группы {3}{2} по дисциплине {0}{2} на {1}",
                                          discipline.name,
                                          exams[0].date.ToShortDateString(),
                                          Environment.NewLine,
                                          group.name),
                                          font);
            par.Alignment = Element.ALIGN_CENTER;
            doc.Add(par);
        }
        private void GenerateReportTableHeaders(ref Document doc, out PdfPTable stTable)
        {
            // Table creation
            stTable = new PdfPTable(6);
            stTable.DefaultCell.Border = 1;
            stTable.WidthPercentage = 100;
            stTable.SpacingBefore = 70f;
            stTable.TotalWidth = 500f;
            stTable.SetWidths(new float[] { 5f, 60f, 20f, 20f, 15f, 15f });
            stTable.LockedWidth = true;
            // End of table creation

            // Header
            Font thFont = new Font(bFont, 13, Font.BOLD, BaseColor.BLACK);
            PdfPHeaderCell headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("№", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("ФИО", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Получено баллов за семестр", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Получено баллов за экзамен", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Всего баллов", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Оценка", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            // Header end
        }
        private void GenerateReportColumns(ref Document doc, ref PdfPTable stTable)
        {
            Font trFont = new Font(bFont, 13, Font.NORMAL, BaseColor.BLACK);
            PdfPCell trCell;
            int iter = 0;

            foreach (Student student in students)
            {
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph((iter + 1).ToString(), trFont) { Alignment = Element.ALIGN_LEFT });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(student.name, trFont) { Alignment = Element.ALIGN_LEFT });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(exams[iter].GetMaxStudentScore().ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(exams[iter].points.ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph((exams[iter].GetMaxSumOfPoints() + 20).ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(exams[iter].CountRecommendedGrade().ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                stTable.AddCell(trCell);
                iter++;
            }
            stTable.SpacingAfter = 25;
            doc.Add(stTable);
        }
        private bool InitializeReportData(int groupID, int disciplineID, int teacherID)
        {
            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
                exams = DataService.SelectStudentsExams(groupID, disciplineID);
                userInfo = DataService.SelectTeacherById(teacherID);
                group = DataService.SelectGroupByID(groupID);
                discipline = DataService.SelectDisciplineById(disciplineID);
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }
            return true;
        }
    }
}
