using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using iTextSharp.text.pdf;
using iTextSharp.text;

namespace AMS.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class CustomersController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _db;

        public CustomersController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment,
                ApplicationDbContext db

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _db = db;
        }

        // GET: Customer
        public ActionResult Index()
        {
            var dd = _db.Customers.Where(x => x.process == "accept" && x.isDeleted == "no").ToList();
            // var tenants = await _unitOfWork.Customers.FindAll();
            var model = _mapper.Map<List<Customer>, List<CustomerVM>>(dd);
            return View(model);
        }


        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(CustomerVM model, ICollection<IFormFile> files)
        {
            try
            {
                //using (var stream = new MemoryStream())
                //{
                //    await FileContent.CopyToAsync(stream);
                //    model.FileContent = stream.ToArray();
                // }

                model.process = "accept";
                model.isDeleted = "no";
                model.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                model.TenantAccess = "2742" + model.Id.ToString();
                var tenant = _mapper.Map<Customer>(model);

                await _unitOfWork.Customers.Create(tenant);

                await _unitOfWork.Save();

                //************************upload file ****************************************
                // Iterate through each file
                foreach (var file in files)
                {
                    // Read the file data into a byte array
                    byte[] fileData;
                    using (var stream = file.OpenReadStream())
                    {
                        fileData = new byte[file.Length];
                        await stream.ReadAsync(fileData, 0, (int)file.Length);
                    }
                    // Create a new FileModel object
                    var fileModel = new CustomerDocument
                    {
                        FileName = file.FileName,
                        FileType = file.ContentType,
                        FileData = fileData,
                        isDeleted = "no",
                        DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"),
                        TenantOrStuff = "tenant",
                        CustomerId = tenant.Id
                    };
                    await _db.CustomerDocuments.AddAsync(fileModel);
                    await _db.SaveChangesAsync();
                }
                //****************************************************************************

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

        // GET: Customer/Edit/5
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Customers.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }


            var tenant = await _unitOfWork.Customers.Find(q => q.Id == id);
            var model = _mapper.Map<CustomerVM>(tenant);

            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        //[AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(CustomerVM model, ICollection<IFormFile> files)
        {
            try
            {
                model.process = "accept";
                model.isDeleted = "no";
                var tenant = _mapper.Map<Customer>(model);


                _unitOfWork.Customers.Update(tenant);
                await _unitOfWork.Save();

                //************************upload file ****************************************
                // Iterate through each file
                foreach (var file in files)
                {
                    // Read the file data into a byte array
                    byte[] fileData;
                    using (var stream = file.OpenReadStream())
                    {
                        fileData = new byte[file.Length];
                        await stream.ReadAsync(fileData, 0, (int)file.Length);
                    }
                    // Create a new FileModel object
                    var fileModel = new CustomerDocument
                    {
                        FileName = file.FileName,
                        FileType = file.ContentType,
                        FileData = fileData,
                        isDeleted = "no",
                        DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt"),
                        TenantOrStuff = "tenant",
                        CustomerId = tenant.Id
                    };
                    await _db.CustomerDocuments.AddAsync(fileModel);
                    await _db.SaveChangesAsync();
                }
                //****************************************************************************

                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var tenant = await _unitOfWork.Customers.Find(expression: q => q.Id == id);
                tenant.isDeleted = "yes";
                tenant.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                if (tenant == null)
                {
                    return NotFound();
                }
                _unitOfWork.Customers.Update(tenant);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Customers.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var tenant = await _unitOfWork.Customers.Find(q => q.Id == id);
            var model = _mapper.Map<CustomerVM>(tenant);
            return View(model);
        }

        public async Task<ActionResult> AdminAdmissionIndex()
        {
            var dd = _db.Customers.Where(x => x.process == "pending").ToList();
            var tenants = await _unitOfWork.Customers.FindAll();
            var model = _mapper.Map<List<Customer>, List<CustomerVM>>(dd);
            return View(model);
        }

        // GET: Customer/Create
        public IActionResult AdminAdmissionCreate()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> AdminAdmissionCreate(CustomerVM model)
        {
            try
            {
                model.process = "pending";

                var tenant = _mapper.Map<Customer>(model);

                await _unitOfWork.Customers.Create(tenant);

                await _unitOfWork.Save();

                return RedirectToAction("AdminAdmissionIndex");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }


        public async Task<ActionResult> Decline(int id)
        {
            try
            {
                var customer_add = await _unitOfWork.Customers.Find(expression: q => q.Id == id);
                if (customer_add == null)
                {
                    return NotFound();
                }
                customer_add.process = "decline";
                customer_add.isDeleted = "no";
                _unitOfWork.Customers.Update(customer_add);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(AdminAdmissionIndex));
        }
        public async Task<ActionResult> Accept(int id)
        {
            try
            {
                var customer_add = await _unitOfWork.Customers.Find(expression: q => q.Id == id);
                if (customer_add == null)
                {
                    return NotFound();
                }
                customer_add.process = "accept";
                customer_add.TenantAccess = "2742" + customer_add.Id.ToString();
                customer_add.isDeleted = "no";
                _unitOfWork.Customers.Update(customer_add);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(AdminAdmissionIndex));
        }

        public async Task<ActionResult> QualityCheckIndex()
        {
            var dd = _db.Customers.Where(x => x.process == "decline").ToList();
            var tenants = await _unitOfWork.Customers.FindAll();
            var model = _mapper.Map<List<Customer>, List<CustomerVM>>(dd);
            return View(model);
        }

        public async Task<ActionResult> ReviewQualityCheck(int id)
        {
            try
            {
                var customer_add = await _unitOfWork.Customers.Find(expression: q => q.Id == id);
                if (customer_add == null)
                {
                    return NotFound();
                }
                customer_add.process = "pending";
                _unitOfWork.Customers.Update(customer_add);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(QualityCheckIndex));
        }

        [HttpGet]
        public IActionResult Download(int id)
        {
            var customer_add = _db.Customers.Find(id);
            // Check if the user has a PDF file
            // if (customer_add.FileContent == null)
            // {
            //    return NotFound();
            // }

            return View();
        }

        public IActionResult ExportToPDF(int id)
        {




            MemoryStream workStream = new MemoryStream();
            Document document = new Document();
            PdfWriter.GetInstance(document, workStream).CloseStream = false;

            document.Open();
            document.Add(new Paragraph("Table Data"));

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;
            PdfPCell cell = new PdfPCell(new Phrase("Table Header"));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 1;
            table.AddCell(cell);

            table.AddCell("Column 1");
            table.AddCell("Column 2");
            table.AddCell("Column 3");

            var data = _db.Customers.ToList();

            foreach (var item in data)
            {
                table.AddCell(item.FirstName);
                table.AddCell(item.LastName);
                table.AddCell(item.IDNumber);
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
