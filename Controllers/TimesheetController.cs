using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AMS.Services;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace AMS.Controllers
{
    [Authorize]
    public class TimesheetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ISmsPortalToken _sms;
        private readonly IEmailSender _email;

        public TimesheetController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                ISmsPortalToken sms,
                IEmailSender email
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _sms = sms;
            _email = email;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Timesheets
                .Include(x => x.Stuff)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }
        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _unitOfWork.Stuffs.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });


            var model = new TimesheetVM
            {
                StuffList = CustomersD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(TimesheetVM model)
        {
            try
            {
                Random rand = new Random();
                int randomNumber = rand.Next(10000000, 90000000);
                model.InvoiceNumber = randomNumber.ToString();

                model.isPaid = "no";
                var invoice = _mapper.Map<Timesheet>(model);
                invoice.isDeleted = "no";
                invoice.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Timesheets.Create(invoice);
                await _unitOfWork.Save();


                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "");
                return View(model);
            }
        }

        // GET: Loan/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var invoiceApp = await _unitOfWork.Timesheets.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Stuff));

            var model = _mapper.Map<EditTimesheetVM>(invoiceApp);

            ViewBag.StuffId = new SelectList(_db.Stuffs.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.StuffId);


            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditTimesheetVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var invoice = _mapper.Map<Timesheet>(model);
                invoice.isDeleted = "no";
                _unitOfWork.Timesheets.Update(invoice);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var invoices = await _unitOfWork.Timesheets.Find(expression: q => q.Id == id);
                if (invoices == null)
                {
                    return NotFound();
                }
                invoices.isDeleted = "yes";
                invoices.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Timesheets.Update(invoices);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Loan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var invoiceApp = await _unitOfWork.Timesheets.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Stuff));

            var model = _mapper.Map<EditTimesheetVM>(invoiceApp);

            ViewBag.StuffId = new SelectList(_db.Stuffs, "Id", "FirstName", model.StuffId);


            return View(model);
        }


        public IActionResult TimesheetReport(int id)
        {

            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Payslip"));

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Payslip for " + DateTime.Now.ToString()));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("IDNumber");
            table.AddCell("Amount");
            table.AddCell("isPaid");

            var data = _db.Timesheets.Include(x => x.Stuff).Where(x => x.Id == id).ToList();

            foreach (var item in data)
            {
                table.AddCell(item.Stuff.IDNumber);
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


    }
}
