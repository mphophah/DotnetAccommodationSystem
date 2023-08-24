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
    public class ParkingTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ParkingTypeController(
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
            var parkingTypes = await _unitOfWork.ParkingTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<ParkingType>, List<ParkingTypeVM>>(parkingTypes.ToList());
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
        public async Task<ActionResult> Create(ParkingTypeVM model)
        {
            try
            {

                var parkingType = _mapper.Map<ParkingType>(model);

                parkingType.isDeleted = "no";
                parkingType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.ParkingTypes.Create(parkingType);

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
            var isExists = await _unitOfWork.ParkingTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var parkingType = await _unitOfWork.ParkingTypes.Find(q => q.Id == id);
            var model = _mapper.Map<ParkingTypeVM>(parkingType);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ParkingTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var parkingType = _mapper.Map<ParkingType>(model);
                parkingType.isDeleted = "no";
                _unitOfWork.ParkingTypes.Update(parkingType);
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
                var parkingType = await _unitOfWork.ParkingTypes.Find(expression: q => q.Id == id);
                if (parkingType == null)
                {
                    return NotFound();
                }
                parkingType.isDeleted = "yes";
                parkingType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.ParkingTypes.Update(parkingType);
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
            var isExists = await _unitOfWork.ParkingTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var parkingType = await _unitOfWork.ParkingTypes.Find(q => q.Id == id);
            var model = _mapper.Map<ParkingTypeVM>(parkingType);
            return View(model);
        }


    }
}
