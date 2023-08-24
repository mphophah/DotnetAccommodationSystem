using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AMS.Controllers
{
    public class ReportController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public ReportController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;

        }

        public IActionResult MonthlyPayments()
        {

            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Monthly Payments"));

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Table Header"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("IDNumber");
            table.AddCell("Amount");
            table.AddCell("isPaid");

            var data = _db.Invoices.Include(x => x.Customer).ToList();

            foreach (var item in data)
            {
                table.AddCell(item.Customer.IDNumber);
                table.AddCell(item.Amount);
                table.AddCell(item.isPaid);
            }

            document.Add(table);
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", "TableData.pdf");
        }

        public IActionResult MonthlyMaintance()
        {




            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Monthly Maintance"));

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Table Header"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("Maintenance");
            table.AddCell("PropertyName");
            table.AddCell("Description");

            var data = _db.Maintenances.Include(x => x.MaintenanceType).Include(x => x.Property).ToList();

            foreach (var item in data)
            {
                table.AddCell(item.MaintenanceType.MaintenanceTypeName);
                table.AddCell(item.Property.PropertyName);
                table.AddCell(item.Description);
            }

            document.Add(table);
            document.Close();

            byte[] byteInfo = workStream.ToArray();
            workStream.Write(byteInfo, 0, byteInfo.Length);
            workStream.Position = 0;

            return File(workStream, "application/pdf", "TableData.pdf");
        }


    }
}
