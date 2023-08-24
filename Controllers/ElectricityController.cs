using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AMS.Controllers
{
    [Authorize]
    public class ElectricityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public ElectricityController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Electricitys
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var Customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var Propertys = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = Customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var PropertysD = Propertys.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });



            var model = new ElectricityVM
            {
                CustomerList = CustomersD,
                PropertyList = PropertysD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ElectricityVM model)
        {


            try
            {
                var electricity = _mapper.Map<Electricity>(model);
                electricity.isDeleted = "no";
                electricity.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Electricitys.Create(electricity);
                await _unitOfWork.Save();


                return RedirectToAction("index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "");
                return View(model);
            }
        }

        // GET: Loan/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var electricityApp = await _unitOfWork.Electricitys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property));

            var model = _mapper.Map<EditElectricityVM>(electricityApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ElectricityVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var electricity = _mapper.Map<Electricity>(model);
                electricity.isDeleted = "no";
                _unitOfWork.Electricitys.Update(electricity);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var electricity = await _unitOfWork.Electricitys.Find(expression: q => q.Id == id);
                if (electricity == null)
                {
                    return NotFound();
                }
                electricity.isDeleted = "yes";
                electricity.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Electricitys.Update(electricity);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Loan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var electricityApp = await _unitOfWork.Electricitys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property));

            var model = _mapper.Map<EditElectricityVM>(electricityApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);

            return View(model);
        }


    }
}
