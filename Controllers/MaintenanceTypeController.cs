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


namespace AMS.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class MaintenanceTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MaintenanceTypeController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: Customer
        public async Task<ActionResult> Index()
        {
            var maintenanceTypes = await _unitOfWork.MaintenanceTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<MaintenanceType>, List<MaintenanceTypeVM>>(maintenanceTypes.ToList());
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
        public async Task<ActionResult> Create(MaintenanceTypeVM model)
        {
            try
            {

                var maintenanceType = _mapper.Map<MaintenanceType>(model);
                maintenanceType.isDeleted = "no";
                maintenanceType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");

                await _unitOfWork.MaintenanceTypes.Create(maintenanceType);

                await _unitOfWork.Save();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.MaintenanceTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var maintenanceType = await _unitOfWork.MaintenanceTypes.Find(q => q.Id == id);
            var model = _mapper.Map<MaintenanceTypeVM>(maintenanceType);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MaintenanceTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var maintenanceType = _mapper.Map<MaintenanceType>(model);
                maintenanceType.isDeleted = "no";
                _unitOfWork.MaintenanceTypes.Update(maintenanceType);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
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
                var maintenanceType = await _unitOfWork.MaintenanceTypes.Find(expression: q => q.Id == id);
                if (maintenanceType == null)
                {
                    return NotFound();
                }
                maintenanceType.isDeleted = "yes";
                maintenanceType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.MaintenanceTypes.Update(maintenanceType);
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
            var isExists = await _unitOfWork.MaintenanceTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var maintenanceType = await _unitOfWork.MaintenanceTypes.Find(q => q.Id == id);
            var model = _mapper.Map<MaintenanceTypeVM>(maintenanceType);
            return View(model);
        }


    }
}
