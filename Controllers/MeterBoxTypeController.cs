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
    public class MeterBoxTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MeterBoxTypeController(
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
            var meterBoxType = await _unitOfWork.MeterBoxTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<MeterBoxType>, List<MeterBoxTypeVM>>(meterBoxType.ToList());
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
        public async Task<ActionResult> Create(MeterBoxTypeVM model)
        {
            try
            {

                var meterBoxType = _mapper.Map<MeterBoxType>(model);
                meterBoxType.isDeleted = "no";
                meterBoxType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");

                await _unitOfWork.MeterBoxTypes.Create(meterBoxType);

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
            var isExists = await _unitOfWork.MeterBoxTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var meterBoxType = await _unitOfWork.MeterBoxTypes.Find(q => q.Id == id);
            var model = _mapper.Map<MeterBoxTypeVM>(meterBoxType);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MeterBoxTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var meterBoxType = _mapper.Map<MeterBoxType>(model);
                meterBoxType.isDeleted = "no";
                _unitOfWork.MeterBoxTypes.Update(meterBoxType);
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
                var meterBoxType = await _unitOfWork.MeterBoxTypes.Find(expression: q => q.Id == id);
                if (meterBoxType == null)
                {
                    return NotFound();
                }
                meterBoxType.isDeleted = "yes";
                meterBoxType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.MeterBoxTypes.Update(meterBoxType);
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
            var isExists = await _unitOfWork.MeterBoxTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var meterBoxType = await _unitOfWork.MeterBoxTypes.Find(q => q.Id == id);
            var model = _mapper.Map<MeterBoxTypeVM>(meterBoxType);
            return View(model);
        }


    }
}
