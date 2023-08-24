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
    public class AssetTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public AssetTypeController(
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
            var assetTypes = await _unitOfWork.AssetTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<AssetType>, List<AssetTypeVM>>(assetTypes.ToList());
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
        public async Task<ActionResult> Create(AssetTypeVM model)
        {
            try
            {

                var assetType = _mapper.Map<AssetType>(model);

                assetType.isDeleted = "no";
                assetType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.AssetTypes.Create(assetType);

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
            var isExists = await _unitOfWork.AssetTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var assetType = await _unitOfWork.AssetTypes.Find(q => q.Id == id);
            var model = _mapper.Map<AssetTypeVM>(assetType); //changed from customerVm
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AssetTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var assetType = _mapper.Map<AssetType>(model);
                assetType.isDeleted = "no";
                _unitOfWork.AssetTypes.Update(assetType);
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
                var assetType = await _unitOfWork.AssetTypes.Find(expression: q => q.Id == id);
                if (assetType == null)
                {
                    return NotFound();
                }
                assetType.isDeleted = "yes";
                assetType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.AssetTypes.Update(assetType);
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
            var isExists = await _unitOfWork.AssetTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var assetType = await _unitOfWork.AssetTypes.Find(q => q.Id == id);
            var model = _mapper.Map<AssetTypeVM>(assetType);
            return View(model);
        }


    }
}
