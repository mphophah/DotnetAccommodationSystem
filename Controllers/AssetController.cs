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
    public class AssetController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public AssetController(
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
            return View(await _db.Assets
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Include(x => x.AssetType)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var Customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var AssetTypes = await _unitOfWork.AssetTypes.FindAll(expression: q => q.isDeleted == "no");
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

            var AssetTypeD = AssetTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new AssetVM
            {
                CustomerList = CustomersD,
                PropertyList = PropertysD,
                AssetTypeList = AssetTypeD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AssetVM model)
        {


            try
            {

                var loans = _mapper.Map<Asset>(model);
                loans.isDeleted = "no";
                loans.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Assets.Create(loans);
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
            var assetsApp = await _unitOfWork.Assets.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.AssetType));

            var model = _mapper.Map<EditAssetVM>(assetsApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes.Where(x => x.isDeleted == "no"), "Id", "Name", model.AssetTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AssetVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var asset = _mapper.Map<Asset>(model);
                asset.isDeleted = "no";
                _unitOfWork.Assets.Update(asset);
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
                var asset = await _unitOfWork.Assets.Find(expression: q => q.Id == id);
                if (asset == null)
                {
                    return NotFound();
                }
                asset.isDeleted = "yes";
                asset.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Assets.Update(asset);
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
            var assetsApp = await _unitOfWork.Assets.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.AssetType));

            var model = _mapper.Map<EditAssetVM>(assetsApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);
            ViewBag.AssetTypeId = new SelectList(_db.AssetTypes.Where(x => x.isDeleted == "no"), "Id", "Name", model.AssetTypeId);

            return View(model);
        }


    }
}
