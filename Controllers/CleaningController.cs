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
    public class CleaningController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Employee> _userManager;
        public CleaningController(
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
            return View(await _db.Cleanings
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }


        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var propertys = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no");

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


            var model = new CleaningVM
            {
                CustomerList = CustomersD,
                PropertyList = PropertysD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CleaningVM model)
        {


            try
            {
                var cleaning = _mapper.Map<Cleaning>(model);
                cleaning.isDeleted = "no";
                cleaning.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Cleanings.Create(cleaning);
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
            var cleaningApp = await _unitOfWork.Cleanings.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property));

            var model = _mapper.Map<EditCleaningVM>(cleaningApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CleaningVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var cleaning = _mapper.Map<Cleaning>(model);
                cleaning.isDeleted = "no";
                _unitOfWork.Cleanings.Update(cleaning);
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
                var cleanings = await _unitOfWork.Cleanings.Find(expression: q => q.Id == id);
                if (cleanings == null)
                {
                    return NotFound();
                }
                cleanings.isDeleted = "yes";
                cleanings.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Cleanings.Update(cleanings);
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
            var cleaningApp = await _unitOfWork.Cleanings.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property));

            var model = _mapper.Map<EditCleaningVM>(cleaningApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);

            return View(model);
        }

    }
}
