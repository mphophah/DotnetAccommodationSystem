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
    public class ManagePropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public ManagePropertyController(
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
            return View(await _db.ManagePropertys
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Include(x => x.RentType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }
        public async Task<ActionResult> Occupied()
        {
            return View(await _db.ManagePropertys
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Include(x => x.RentType).
                Where(x => x.Property.Occupied == "yes")
                .ToListAsync());
        }
        public async Task<ActionResult> Vaccant()
        {
            return View(await _db.ManagePropertys
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Include(x => x.RentType).
                Where(x => x.Property.Occupied == "no")
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var propertys = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no" && q.Occupied == "no");
            var rentTypes = await _unitOfWork.RentTypes.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var PropertysD = propertys.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });

            var RentTypesD = rentTypes.Select(q => new SelectListItem
            {
                Text = q.RentTypeName,
                Value = q.Id.ToString()
            });

            var model = new ManagePropertyVM
            {
                CustomerList = CustomersD,
                PropertyList = PropertysD,
                RentTypeList = RentTypesD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ManagePropertyVM model)
        {


            try
            {
                var m = _db.Propertys.Find(model.PropertyId);
                m.Occupied = "yes";
                var manageProperty = _mapper.Map<ManageProperty>(model);
                manageProperty.isDeleted = "no";
                manageProperty.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.ManagePropertys.Create(manageProperty);
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
            var managePropertyApp = await _unitOfWork.ManagePropertys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.RentType));

            var model = _mapper.Map<EditManagePropertyVM>(managePropertyApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);
            ViewBag.RentTypeId = new SelectList(_db.RentTypes.Where(x => x.isDeleted == "no"), "Id", "RentTypeName", model.RentTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ManagePropertyVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var manageProperty = _mapper.Map<ManageProperty>(model);
                manageProperty.isDeleted = "no";
                _unitOfWork.ManagePropertys.Update(manageProperty);
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
                var managePropertys = await _unitOfWork.ManagePropertys.Find(expression: q => q.Id == id);
                if (managePropertys == null)
                {
                    return NotFound();
                }
                var m = _db.Propertys.Find(managePropertys.PropertyId);
                m.Occupied = "no";

                managePropertys.isDeleted = "yes";
                managePropertys.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.ManagePropertys.Update(managePropertys);
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
            var managePropertyApp = await _unitOfWork.ManagePropertys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.RentType));

            var model = _mapper.Map<EditManagePropertyVM>(managePropertyApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);
            ViewBag.RentTypeId = new SelectList(_db.RentTypes, "Id", "RentTypeName", model.RentTypeId);

            return View(model);
        }


    }
}
