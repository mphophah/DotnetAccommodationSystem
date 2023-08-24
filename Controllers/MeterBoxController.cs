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
    public class MeterBoxController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public MeterBoxController(
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
            return View(await _db.MeterBoxs
                .Include(x => x.Property)
                .Include(x => x.MeterBoxType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var property = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no");
            var meterBoxType = await _unitOfWork.MeterBoxTypes.FindAll(expression: q => q.isDeleted == "no");

            var PropertyD = property.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });

            var MeterBoxTypeD = meterBoxType.Select(q => new SelectListItem
            {
                Text = q.MeterBoxName,
                Value = q.Id.ToString()
            });


            var model = new MeterBoxVM
            {
                PropertyList = PropertyD,
                MeterBoxTypeList = MeterBoxTypeD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(MeterBoxVM model)
        {


            try
            {
                var meterBox = _mapper.Map<MeterBox>(model);
                meterBox.isDeleted = "no";
                meterBox.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.MeterBoxs.Create(meterBox);
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
            var meterBoxTApp = await _unitOfWork.MeterBoxs.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Property)
            .Include(x => x.MeterBoxType));

            var model = _mapper.Map<EditMeterBoxVM>(meterBoxTApp);

            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);
            ViewBag.MeterBoxTypeId = new SelectList(_db.MeterBoxTypes.Where(x => x.isDeleted == "no"), "Id", "MeterBoxName", model.MeterBoxTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(MeterBoxVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var meterBox = _mapper.Map<MeterBox>(model);
                meterBox.isDeleted = "no";
                _unitOfWork.MeterBoxs.Update(meterBox);
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
                var meterBoxs = await _unitOfWork.MeterBoxs.Find(expression: q => q.Id == id);
                if (meterBoxs == null)
                {
                    return NotFound();
                }
                meterBoxs.isDeleted = "yes";
                meterBoxs.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.MeterBoxs.Update(meterBoxs);
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
            var meterBoxTApp = await _unitOfWork.MeterBoxs.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Property)
            .Include(x => x.MeterBoxType));

            var model = _mapper.Map<EditMeterBoxVM>(meterBoxTApp);

            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);
            ViewBag.MeterBoxTypeId = new SelectList(_db.MeterBoxTypes, "Id", "MeterBoxName", model.MeterBoxTypeId);

            return View(model);
        }


    }
}
