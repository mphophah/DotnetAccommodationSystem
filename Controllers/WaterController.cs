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
    public class WaterController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public WaterController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;

        }

        // GET: AssetType
        public async Task<ActionResult> Index()
        {
            var waters = await _unitOfWork.Waters.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<Water>, List<WaterVM>>(waters.ToList());
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
        public async Task<ActionResult> Create(WaterVM model)
        {
            try
            {

                var water = _mapper.Map<Water>(model);

                water.isDeleted = "no";
                water.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Waters.Create(water);

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
            var isExists = await _unitOfWork.Waters.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var water = await _unitOfWork.Waters.Find(q => q.Id == id);
            var model = _mapper.Map<WaterVM>(water);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(WaterVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var water = _mapper.Map<Water>(model);
                water.isDeleted = "no";
                _unitOfWork.Waters.Update(water);
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
                var water = await _unitOfWork.Waters.Find(expression: q => q.Id == id);
                if (water == null)
                {
                    return NotFound();
                }
                water.isDeleted = "yes";
                water.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Waters.Update(water);
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
            var isExists = await _unitOfWork.Waters.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var water = await _unitOfWork.Waters.Find(q => q.Id == id);
            var model = _mapper.Map<WaterVM>(water);
            return View(model);
        }


    }
}
