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
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using AMS.Services;

namespace AMS.Controllers
{
    [Authorize]
    public class InvoiceController : Controller
    {
        //private readonly IPdfService<Invoice> _pdfService;
        //private readonly IGeneratePdf _generatePdf;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ISmsPortalToken _sms;
        private readonly IEmailSender _email;

        public InvoiceController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                ISmsPortalToken sms,
                IEmailSender email
                // IPdfService<Invoice> pdfService,
                // IGeneratePdf generatePdf
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _sms = sms;
            _email = email;
            // _pdfService = pdfService;
            // _generatePdf = generatePdf;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Invoices
                .Include(x => x.Customer)
                .Include(x => x.RentType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }
        public async Task<ActionResult> Unpaid()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Invoices
                .Include(x => x.Customer)
                .Include(x => x.RentType)
                .ToListAsync());
        }
        public async Task<ActionResult> Overdue()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Invoices
                .Include(x => x.Customer)
                .Include(x => x.RentType)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var rentTypes = await _unitOfWork.RentTypes.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var RentTypesD = rentTypes.Select(q => new SelectListItem
            {
                Text = q.RentTypeName,
                Value = q.Id.ToString()
            });



            var model = new InvoiceVM
            {
                CustomerList = CustomersD,
                RentTypeList = RentTypesD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InvoiceVM model)
        {


            try
            {

                Random rand = new Random();
                int randomNumber = rand.Next(10000000, 90000000);
                model.InvoiceNumber = randomNumber.ToString();

                model.isPaid = "no";
                var invoice = _mapper.Map<Invoice>(model);
                invoice.isDeleted = "no";
                invoice.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Invoices.Create(invoice);
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
            var invoiceApp = await _unitOfWork.Invoices.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.RentType));

            var model = _mapper.Map<EditInvoiceVM>(invoiceApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.RentTypeId = new SelectList(_db.RentTypes.Where(x => x.isDeleted == "no"), "Id", "RentTypeName", model.RentTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditInvoiceVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var invoice = _mapper.Map<Invoice>(model);
                invoice.isDeleted = "no";
                _unitOfWork.Invoices.Update(invoice);
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
                var invoices = await _unitOfWork.Invoices.Find(expression: q => q.Id == id);
                if (invoices == null)
                {
                    return NotFound();
                }
                invoices.isDeleted = "yes";
                invoices.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Invoices.Update(invoices);
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
            var invoiceApp = await _unitOfWork.Invoices.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.RentType));

            var model = _mapper.Map<EditInvoiceVM>(invoiceApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.RentTypeId = new SelectList(_db.RentTypes, "Id", "RentTypeName", model.RentTypeId);

            return View(model);
        }
        public async Task<ActionResult> isPaid(int id)
        {
            try
            {
                var payment = await _unitOfWork.Invoices.Find(expression: q => q.Id == id);
                if (payment == null)
                {
                    return NotFound();
                }
                payment.isPaid = "yes";
                _unitOfWork.Invoices.Update(payment);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> GenerateInvoices()
        {
            /*string MailBody = "<!DOCTYPE html>" +
                                    "<html> " +
                                        "<body style=\"background -color:#ff7f26;text-align:center;\"> " +
                                        "<h1 style=\"color:#051a80;\">Payment Reminder Email</h1> " +
                                        "<h2 style=\"color:#fff;\">Please play your rent on time.</h2> " +
                                        "<label style=\"color:orange;font-size:100px;border:5px dotted;border-radius:50px\">N</label> " +
                                        "</body> " +
                                    "</html>"; */

            Random rand = new Random();
            int randomNumber = rand.Next(10000000, 90000000);

            List<Customer> customers = await _db.Customers.Where(x => x.isDeleted == "no").ToListAsync();
            foreach (Customer customer in customers)
            {
                // code to generate invoice for each customer
                Invoice invoice = new Invoice
                {
                    CustomerId = customer.Id,
                    Amount = "5000",
                    RentTypeId = 1,
                    InvoiceNumber = customer.Id.ToString() + randomNumber.ToString(),
                    isDeleted = "no",
                    isPaid = "no"
                };
                await _unitOfWork.Invoices.Create(invoice);
                await _unitOfWork.Save();
                //send sms +27648917183
                //await _sms.SendSms("Yes", customer.PhoneNumber);
                //send email
                //await _email.SendEmailAsync("mphophahhh@gmail.com", "Payment Reminder", MailBody);
            }

            return RedirectToAction(nameof(Index));
        }
        /*
        public async Task<IActionResult> Print(int id)
        {
            var isExists = await _unitOfWork.Invoices.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var invoice = await _unitOfWork.Invoices.Find(q => q.Id == id);

            return await _generatePdf.GetPdf("Views/Templates/InvoicePdf.cshtml", invoice);
        }
        */
    }
}
