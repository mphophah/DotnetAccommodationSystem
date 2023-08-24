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
    public class RentTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public RentTypeController(
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
            var rentType = await _unitOfWork.RentTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<RentType>, List<RentTypeVM>>(rentType.ToList());
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
        public async Task<ActionResult> Create(RentTypeVM model)
        {
            try
            {

                var rentType = _mapper.Map<RentType>(model);

                rentType.isDeleted = "no";
                rentType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.RentTypes.Create(rentType);

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
            var isExists = await _unitOfWork.RentTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var rentType = await _unitOfWork.RentTypes.Find(q => q.Id == id);
            var model = _mapper.Map<RentTypeVM>(rentType);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(RentTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var rentType = _mapper.Map<RentType>(model);
                rentType.isDeleted = "no";
                _unitOfWork.RentTypes.Update(rentType);
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
                var rentType = await _unitOfWork.RentTypes.Find(expression: q => q.Id == id);
                if (rentType == null)
                {
                    return NotFound();
                }
                rentType.isDeleted = "yes";
                rentType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.RentTypes.Update(rentType);
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
            var isExists = await _unitOfWork.RentTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var rentType = await _unitOfWork.RentTypes.Find(q => q.Id == id);
            var model = _mapper.Map<RentTypeVM>(rentType);
            return View(model);
        }


    }
}
