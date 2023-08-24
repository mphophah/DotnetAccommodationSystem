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
    public class ParkingController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public ParkingController(
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
            return View(await _db.Parkings
                .Include(x => x.ParkingType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var parkingtypes = await _unitOfWork.ParkingTypes.FindAll(expression: q => q.isDeleted == "no");

            var parkingsD = parkingtypes.Select(q => new SelectListItem
            {
                Text = q.ParkingTypeName,
                Value = q.Id.ToString()
            });

            var model = new ParkingVM
            {
                ParkingTypeList = parkingsD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ParkingVM model)
        {


            try
            {
                var parking = _mapper.Map<Parking>(model);
                parking.isDeleted = "no";
                parking.isAvailable = "yes";
                parking.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Parkings.Create(parking);
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
            var parkingApp = await _unitOfWork.Parkings.Find(q => q.Id == id,
            includes: q => q.Include(x => x.ParkingType));

            var model = _mapper.Map<EditParkingVM>(parkingApp);

            ViewBag.ParkingTypeId = new SelectList(_db.ParkingTypes.Where(x => x.isDeleted == "no"), "Id", "ParkingTypeName", model.ParkingTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ParkingVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var parking = _mapper.Map<Parking>(model);
                parking.isDeleted = "no";
                _unitOfWork.Parkings.Update(parking);
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
                var parking = await _unitOfWork.Parkings.Find(expression: q => q.Id == id);
                if (parking == null)
                {
                    return NotFound();
                }
                parking.isDeleted = "yes";
                parking.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Parkings.Update(parking);
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
            var parkingApp = await _unitOfWork.Parkings.Find(q => q.Id == id,
            includes: q => q.Include(x => x.ParkingType));

            var model = _mapper.Map<EditParkingVM>(parkingApp);

            ViewBag.ParkingTypeId = new SelectList(_db.ParkingTypes, "Id", "ParkingTypeNames", model.ParkingTypeId);

            return View(model);
        }


    }
}
