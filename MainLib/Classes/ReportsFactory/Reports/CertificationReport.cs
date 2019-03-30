﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainLib.DBServices;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace MainLib.ReportsFactory.Reports
{
    public class CertificationReport : IReport
    {
        private NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        private List<StudentCertification> certifications;
        private List<Student> students;
        private UserInfo userInfo;
        private Discipline discipline;
        private Group group;

        private BaseFont bFont = BaseFont.CreateFont(@"tnr.ttf", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

        public bool GenerateReport(string folderPath, int groupID, int disciplineID, int teacherID)
        {

            if (!InitializeReportData(groupID, disciplineID, teacherID))
                return false;

            Document doc = new Document(PageSize.A4);

            doc.Open();
            var output = new FileStream($"Аттестация_{group.name}_{DateTime.Now.ToShortDateString()}.pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(doc, output);

            doc.Close();
            return true;
        }
        private void GenerateReportHeader(ref Document doc)
        {
            Font font = new Font(bFont, 15, Font.NORMAL, BaseColor.BLACK);

            Paragraph par = new Paragraph(string.Format("Отчет по аттестации на {0}{1}группы {2}", certifications[0].date, 
                                          Environment.NewLine, students[0].id_of_group), font);
            par.Alignment = Element.ALIGN_CENTER;
            doc.Add(par);
        }
        private void GenerateReportTableHeaders(ref Document doc, out PdfPTable stTable)
        {
            // Table creation
            stTable = new PdfPTable(5);
            stTable.DefaultCell.Border = 1;
            stTable.WidthPercentage = 100;
            stTable.SpacingBefore = 70f;
            stTable.TotalWidth = 500f;
            stTable.SetWidths(new float[] { 5f, 50f, 25f, 20f, 15f });
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
            headerCell.AddElement(new Paragraph("Получено баллов", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Всего баллов", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            headerCell = new PdfPHeaderCell();
            headerCell.AddElement(new Paragraph("Оценка", thFont) { Alignment = Element.ALIGN_CENTER });
            stTable.AddCell(headerCell);
            // Header end
        }
        private void GenerateReportColumns(ref Document doc, PdfPTable stTable)
        {
            Font trFont = new Font(bFont, 13, Font.NORMAL, BaseColor.BLACK);
            PdfPCell trCell;
            int iter = 0;

            foreach (Student student in students)
            {
                iter++;
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(iter.ToString(), trFont) { Alignment = Element.ALIGN_LEFT });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                trCell.AddElement(new Paragraph(student.name, trFont) { Alignment = Element.ALIGN_LEFT });
                stTable.AddCell(trCell);
                trCell = new PdfPCell();
                //trCell.AddElement(new Paragraph(certifications[0].GetMaxSumOfPoints, trFont) { Alignment = Element.ALIGN_CENTER });
                //stTable.AddCell(trCell);
                //trCell = new PdfPCell();
                //trCell.AddElement(new Paragraph(student.getSumOfPoints(2).ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                //stTable.AddCell(trCell);
                //trCell = new PdfPCell();
                //trCell.AddElement(new Paragraph(student.certGrades[0].ToString(), trFont) { Alignment = Element.ALIGN_CENTER });
                //stTable.AddCell(trCell);
            }
            stTable.SpacingAfter = 25;
            doc.Add(stTable);
        }

        private bool InitializeReportData(int groupID, int disciplineID, int teacherID)
        {
            try
            {
                students = DataService.SelectStudentsByGroupId(groupID);
                certifications = DataService.SelectStudentsCertifications(groupID, disciplineID);
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
