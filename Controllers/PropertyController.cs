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
    public class PropertyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public PropertyController(
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
            return View(await _db.Propertys
                .Include(x => x.Parking)
                .Include(x => x.PropertyType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public ActionResult Create()
        {
            var parking = _db.Parkings.Where(x => x.isDeleted == "no").ToList();
            var propertyType = _db.PropertyTypes.Where(x => x.isDeleted == "no").ToList();

            var parkingD = parking.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var PropertyTypeD = propertyType.Select(q => new SelectListItem
            {
                Text = q.PropertyTypeName,
                Value = q.Id.ToString()
            });


            var model = new PropertyVM
            {
                ParkingList = parkingD,
                PropertyTypeList = PropertyTypeD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PropertyVM model)
        {

            try
            {
                var parking = _db.Parkings.Where(x => x.Id == model.ParkingId).First();

                var property = _mapper.Map<Property>(model);
                property.isDeleted = "no";
                property.Occupied = "no";
                property.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Propertys.Create(property);
                await _unitOfWork.Save();

                parking.isAvailable = "no";
                _db.Parkings.Update(parking);
                _db.SaveChanges();


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
            var meterBoxTApp = await _unitOfWork.Propertys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Parking)
            .Include(x => x.PropertyType));

            var model = _mapper.Map<EditPropertyVM>(meterBoxTApp);

            ViewBag.ParkingId = new SelectList(_db.Parkings.Where(x => x.isDeleted == "no"), "Id", "Name", model.ParkingId);
            ViewBag.PropertyTypeId = new SelectList(_db.PropertyTypes.Where(x => x.isDeleted == "no"), "Id", "PropertyTypeName", model.PropertyTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PropertyVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var property = _mapper.Map<Property>(model);
                property.isDeleted = "no";
                _unitOfWork.Propertys.Update(property);
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
                var propertys = await _unitOfWork.Propertys.Find(expression: q => q.Id == id);

                var parking = _db.Parkings.Where(x => x.Id == propertys.ParkingId).First();

                if (propertys == null)
                {
                    return NotFound();
                }
                propertys.isDeleted = "yes";
                propertys.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Propertys.Update(propertys);
                await _unitOfWork.Save();

                parking.isAvailable = "no";
                _db.Parkings.Update(parking);
                _db.SaveChanges();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Loan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var meterBoxTApp = await _unitOfWork.Propertys.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Parking)
            .Include(x => x.PropertyType));

            var model = _mapper.Map<EditPropertyVM>(meterBoxTApp);

            ViewBag.ParkingId = new SelectList(_db.Parkings.Where(x => x.isDeleted == "no"), "Id", "Name", model.ParkingId);
            ViewBag.PropertyTypeId = new SelectList(_db.PropertyTypes.Where(x => x.isDeleted == "no"), "Id", "PropertyTypeName", model.PropertyTypeId);

            return View(model);
        }


    }
}
