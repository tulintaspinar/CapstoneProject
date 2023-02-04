using CapstoneProject_EntityLayer.Concrete;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;

namespace CapstoneProject.Controllers
{
    public class ReportController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ReportController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult TotalEmployee()
        {
            MemoryStream workStream = new MemoryStream();

            Document doc = new Document();
            doc.SetMargins(0, 0, 0, 0);
            PdfPTable tableLayout = new PdfPTable(7);
            doc.SetMargins(10, 10, 10, 0);
            PdfWriter.GetInstance(doc, workStream).CloseStream = false;
            doc.Open();
            BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fontInvoice = new Font(bf, 20, Font.NORMAL);
            Paragraph paragraph = new Paragraph("EMPLOYEE LIST", fontInvoice);
            paragraph.Alignment = Element.ALIGN_CENTER;
            doc.Add(paragraph);
            Paragraph p3 = new Paragraph();
            p3.SpacingAfter = 6;
            doc.Add(p3);
            doc.Add(Add_Content_To_PDF(tableLayout));
            doc.Close();
            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;
            return File(workStream, "application/pdf", "TotalEmployee.pdf");
        }

        protected PdfPTable Add_Content_To_PDF(PdfPTable tableLayout)
        {
            var users = _userManager.Users.ToList();
            float[] headers = { 40, 15, 20, 15, 10, 10, 15 }; //Header Widths  
            tableLayout.SetWidths(headers); //Set the pdf headers  
            tableLayout.WidthPercentage = 100; //Set the PDF File witdh percentage  
            tableLayout.HeaderRows = 1;
            var count = 1;
            //Add header  
            AddCellToHeader(tableLayout, "Name & Surname");
            AddCellToHeader(tableLayout, "Phone Number");
            AddCellToHeader(tableLayout, "Email");
            AddCellToHeader(tableLayout, "Job");
            AddCellToHeader(tableLayout, "Salary");
            AddCellToHeader(tableLayout, "Age");
            AddCellToHeader(tableLayout, "Join Date");

            foreach (var cust in users)
            {
                if (count >= 1)
                {
                    //Add body  
                    AddCellToBody(tableLayout, cust.Name + " " + cust.Surname, count);
                    AddCellToBody(tableLayout, cust.PhoneNumber.ToString(), count);
                    AddCellToBody(tableLayout, cust.Email.ToString(), count);
                    AddCellToBody(tableLayout, cust.Job.ToString(), count);
                    AddCellToBody(tableLayout, cust.Salary.ToString(), count);
                    AddCellToBody(tableLayout, cust.Age.ToString(), count);
                    AddCellToBody(tableLayout, cust.JoinDate.ToShortDateString().ToString(), count);
                    count++;
                }
            }
            return tableLayout;
        }
        private static void AddCellToHeader(PdfPTable tableLayout, string cellText)
        {
            tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
            {
                HorizontalAlignment = Element.ALIGN_LEFT,
                Padding = 8,
                BackgroundColor = new BaseColor(255, 255, 255)
            });
        }
        private static void AddCellToBody(PdfPTable tableLayout, string cellText, int count)
        {
            if (count % 2 == 0)
            {
                tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Padding = 8,
                    BackgroundColor = new BaseColor(255, 255, 255)
                });
            }
            else
            {
                tableLayout.AddCell(new PdfPCell(new Phrase(cellText, new Font(Font.FontFamily.HELVETICA, 8, 1, BaseColor.BLACK)))
                {
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    Padding = 8,
                    BackgroundColor = new BaseColor(211, 211, 211)
                });
            }
        }
    }
}
