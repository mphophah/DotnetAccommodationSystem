using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using AMS.Services;
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
    public class VisitorController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ISmsPortalToken _sms;
        private readonly IEmailSender _email;


        public VisitorController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                ISmsPortalToken sms,
                IEmailSender email
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _sms = sms;
            _email = email;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Visitors
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Include(x => x.Parking)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var customer = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var property = await _unitOfWork.Propertys.FindAll(expression: q => q.isDeleted == "no");
            var parking = await _unitOfWork.Parkings.FindAll(expression: q => q.isDeleted == "no");


            var parkingD = parking.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var CustomerD = customer.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var PropertyD = property.Select(q => new SelectListItem
            {
                Text = q.PropertyName,
                Value = q.Id.ToString()
            });


            var model = new VisitorVM
            {
                CustomerList = CustomerD,
                PropertyList = PropertyD,
                ParkingList = parkingD,
            };



            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(VisitorVM model)
        {

            try
            {
                var parking = _db.Parkings.Where(x => x.Id == model.ParkingId).First();

                Random rand = new Random();
                int randomNumber = rand.Next(1000000, 9000000);


                if (model.IsChecked == "true")
                {
                    //send message to the visitor with confirmation code 
                    //await _sms.SendSms("Hello Mpho", "+27648917189");
                }

                model.ConfirmationCode = randomNumber.ToString();
                model.Accept = "pending";
                var visitor = _mapper.Map<Visitor>(model);
                visitor.isDeleted = "no";
                visitor.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                visitor.CheckOut = "false";
                await _unitOfWork.Visitors.Create(visitor);
                await _unitOfWork.Save();

                parking.isAvailable = "no";
                _db.Parkings.Update(parking);
                _db.SaveChanges();
                //await _email.SendEmailAsync("mphophahhh@gmail.com","test","mpho email");

                //await _sms.SendSms("Hello Mpho", "+27648917189");
                //SmsUsage sMs = new SmsUsage();
                //sMs.Receiver = "mpho";
                //sMs.Sender = "mpho";
                //sMs.SmsDate = "mpho";
                // sMs.SmsResoan = "mpho";
                //await _unitOfWork.SmsUsages.Create(sMs);
                //await _unitOfWork.Save();

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
            var visitorApp = await _unitOfWork.Visitors.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.Parking));

            var model = _mapper.Map<EditVisitorVM>(visitorApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys.Where(x => x.isDeleted == "no"), "Id", "PropertyName", model.PropertyId);
            ViewBag.ParkingId = new SelectList(_db.Parkings.Where(x => x.isAvailable == "no"), "Id", "Name", model.ParkingId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(VisitorVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var visitor = _mapper.Map<Visitor>(model);
                visitor.isDeleted = "no";
                _unitOfWork.Visitors.Update(visitor);
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
                var visitors = await _unitOfWork.Visitors.Find(expression: q => q.Id == id);

                var parking = _db.Parkings.Where(x => x.Id == visitors.ParkingId).First();


                if (visitors == null)
                {
                    return NotFound();
                }
                visitors.isDeleted = "yes";
                visitors.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Visitors.Update(visitors);
                await _unitOfWork.Save();

                parking.isAvailable = "yes";
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
            var visitorApp = await _unitOfWork.Visitors.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer)
            .Include(x => x.Property)
            .Include(x => x.Parking));


            var model = _mapper.Map<EditVisitorVM>(visitorApp);

            ViewBag.CustomerId = new SelectList(_db.Customers, "Id", "FirstName", model.CustomerId);
            ViewBag.PropertyId = new SelectList(_db.Propertys, "Id", "PropertyName", model.PropertyId);
            ViewBag.ParkingId = new SelectList(_db.Parkings, "Id", "Name", model.ParkingId);

            return View(model);
        }

        public async Task<ActionResult> CheckOut(int id)
        {
            try
            {
                var visitors = await _unitOfWork.Visitors.Find(expression: q => q.Id == id);

                var parking = _db.Parkings.Where(x => x.Id == visitors.ParkingId).First();


                if (visitors == null)
                {
                    return NotFound();
                }
                visitors.CheckOut = "True";
                _unitOfWork.Visitors.Update(visitors);
                await _unitOfWork.Save();

                parking.isAvailable = "yes";
                _db.Parkings.Update(parking);
                _db.SaveChanges();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }




    }
}
