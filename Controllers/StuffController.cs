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
using Microsoft.AspNetCore.Http;

namespace AMS.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class StuffController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _db;

        public StuffController(
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
            var dd = _db.Stuffs.Where(x => x.isDeleted == "no").ToList();
            // var tenants = await _unitOfWork.Customers.FindAll();
            var model = _mapper.Map<List<Stuff>, List<StuffVM>>(dd);
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
        public async Task<ActionResult> Create(StuffVM model, ICollection<IFormFile> files)
        {
            try
            {
                //using (var stream = new MemoryStream())
                //{
                //    await FileContent.CopyToAsync(stream);
                //    model.FileContent = stream.ToArray();
                // }

                model.isDeleted = "no";
                model.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                model.TenantAccess = "2742" + model.Id.ToString();
                var tenant = _mapper.Map<Stuff>(model);

                await _unitOfWork.Stuffs.Create(tenant);

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
                        TenantOrStuff = "stuff",
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
            var isExists = await _unitOfWork.Stuffs.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }


            var tenant = await _unitOfWork.Stuffs.Find(q => q.Id == id);
            var model = _mapper.Map<StuffVM>(tenant);

            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        //[AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Edit(StuffVM model, ICollection<IFormFile> files)
        {
            try
            {
                model.isDeleted = "no";
                var tenant = _mapper.Map<Stuff>(model);


                _unitOfWork.Stuffs.Update(tenant);
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
                        TenantOrStuff = "stuff",
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
                var tenant = await _unitOfWork.Stuffs.Find(expression: q => q.Id == id);
                tenant.isDeleted = "yes";
                tenant.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                if (tenant == null)
                {
                    return NotFound();
                }
                _unitOfWork.Stuffs.Update(tenant);
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
            var isExists = await _unitOfWork.Stuffs.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var tenant = await _unitOfWork.Stuffs.Find(q => q.Id == id);
            var model = _mapper.Map<StuffVM>(tenant);
            return View(model);
        }

    }
}
