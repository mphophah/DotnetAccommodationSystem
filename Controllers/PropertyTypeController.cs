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
    public class PropertyTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public PropertyTypeController(
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
            var propertyType = await _unitOfWork.PropertyTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<PropertyType>, List<PropertyTypeVM>>(propertyType.ToList());
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
        public async Task<ActionResult> Create(PropertyTypeVM model)
        {
            try
            {

                var propertyType = _mapper.Map<PropertyType>(model);

                propertyType.isDeleted = "no";
                propertyType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.PropertyTypes.Create(propertyType);

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
            var isExists = await _unitOfWork.PropertyTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var propertyType = await _unitOfWork.PropertyTypes.Find(q => q.Id == id);
            var model = _mapper.Map<PropertyTypeVM>(propertyType);
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var propertyType = _mapper.Map<PropertyType>(model);
                propertyType.isDeleted = "no";
                _unitOfWork.PropertyTypes.Update(propertyType);
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
                var propertyType = await _unitOfWork.PropertyTypes.Find(expression: q => q.Id == id);
                if (propertyType == null)
                {
                    return NotFound();
                }
                propertyType.isDeleted = "yes";
                propertyType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.PropertyTypes.Update(propertyType);
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
            var isExists = await _unitOfWork.PropertyTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var propertyType = await _unitOfWork.PropertyTypes.Find(q => q.Id == id);
            var model = _mapper.Map<PropertyTypeVM>(propertyType);
            return View(model);
        }


    }
}
