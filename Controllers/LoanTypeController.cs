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
    public class LoanTypeController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public LoanTypeController(
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
            var loanTypes = await _unitOfWork.LoanTypes.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<LoanType>, List<LoanTypeVM>>(loanTypes.ToList());
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
        public async Task<ActionResult> Create(LoanTypeVM model)
        {
            try
            {

                var loanType = _mapper.Map<LoanType>(model);
                loanType.isDeleted = "no";
                loanType.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");

                await _unitOfWork.LoanTypes.Create(loanType);

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
            var isExists = await _unitOfWork.LoanTypes.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var loanType = await _unitOfWork.LoanTypes.Find(q => q.Id == id);
            var model = _mapper.Map<LoanTypeVM>(loanType); //changed from customerVm
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LoanTypeVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var loanType = _mapper.Map<LoanType>(model);
                loanType.isDeleted = "no";
                _unitOfWork.LoanTypes.Update(loanType);
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
                var loanType = await _unitOfWork.LoanTypes.Find(expression: q => q.Id == id);
                if (loanType == null)
                {
                    return NotFound();
                }
                loanType.isDeleted = "yes";
                loanType.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.LoanTypes.Update(loanType);
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
            var isExists = await _unitOfWork.LoanTypes.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var loanType = await _unitOfWork.LoanTypes.Find(q => q.Id == id);
            var model = _mapper.Map<LoanTypeVM>(loanType);
            return View(model);
        }


    }
}
