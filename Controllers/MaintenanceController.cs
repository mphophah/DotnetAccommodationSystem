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
using Microsoft.AspNetCore.Identity;

namespace AMS.Controllers
{
    [Authorize]
    public class MaintenanceController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Employee> _userManager;
        public MaintenanceController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                UserManager<Employee> userManager
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Maintenances
                .Include(x => x.Customer)
                .Include(x => x.MaintenanceType)
                .Include(x => x.Property)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }


        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var maintenanceTypes = await _unitOfWork.MaintenanceTypes.FindAll(expression: q => q.isDeleted == "no");
            var propertys = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var MaintenanceTypesD = maintenanceTypes.Select(q => new SelectListItem
            {
                Text = q.MaintenanceTypeName,
                Value = q.Id.ToString()
            });

            var PropertysD = propertys.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });


            var model = new MaintenanceVM
            {
                CustomerList = CustomersD,
                MaintenanceTypeList = MaintenanceTypesD,
                PropertyList = PropertysD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MaintenanceVM model)
        {


            try
            {
                var invoice = _mapper.Map<Maintenance>(model);
                invoice.isDeleted = "no";
                invoice.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Maintenances.Create(invoice);
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
            var maintenanceApp = await _unitOfWork.Maintenances.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.MaintenanceType)
            .Include(x => x.Property));

            var model = _mapper.Map<EditMaintenanceVM>(maintenanceApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.MaintenanceTypeId = new SelectList(_db.MaintenanceTypes.Where(x => x.isDeleted == "no"), "Id", "MaintenanceTypeName", model.MaintenanceTypeId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MaintenanceVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var maintenance = _mapper.Map<Maintenance>(model);
                maintenance.isDeleted = "no";
                _unitOfWork.Maintenances.Update(maintenance);
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
                var maintenances = await _unitOfWork.Maintenances.Find(expression: q => q.Id == id);
                if (maintenances == null)
                {
                    return NotFound();
                }
                maintenances.isDeleted = "yes";
                maintenances.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Maintenances.Update(maintenances);
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
            var maintenanceApp = await _unitOfWork.Maintenances.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.MaintenanceType)
            .Include(x => x.Property));

            var model = _mapper.Map<EditMaintenanceVM>(maintenanceApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.MaintenanceTypeId = new SelectList(_db.MaintenanceTypes, "Id", "MaintenanceTypeName", model.MaintenanceTypeId);
            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);

            return View(model);
        }

        public async Task<ActionResult> TenantIndex()
        {
            Employee usr = await GetCurrentUserAsync();
            int link = int.Parse(usr.IntrestingKey);
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Maintenances
                .Include(x => x.Customer)
                .Include(x => x.MaintenanceType)
                .Include(x => x.Property)
                .Where(x => x.CustomerId == link && x.isDeleted == "no")
                .ToListAsync());
        }

        public async Task<ActionResult> TenantCreate()
        {
            var customers = await _unitOfWork.Customers.FindAll();
            var maintenanceTypes = await _unitOfWork.MaintenanceTypes.FindAll();
            var propertys = await _unitOfWork.Propertys.FindAll();

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var MaintenanceTypesD = maintenanceTypes.Select(q => new SelectListItem
            {
                Text = q.MaintenanceTypeName,
                Value = q.Id.ToString()
            });

            var PropertysD = propertys.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });


            var model = new MaintenanceVM
            {
                CustomerList = CustomersD,
                MaintenanceTypeList = MaintenanceTypesD,
                PropertyList = PropertysD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TenantCreate(MaintenanceVM model)
        {


            try
            {
                var invoice = _mapper.Map<Maintenance>(model);
                await _unitOfWork.Maintenances.Create(invoice);
                await _unitOfWork.Save();


                return RedirectToAction("TenantIndex");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, "");
                return View(model);
            }
        }


    }
}
