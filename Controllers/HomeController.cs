using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using AMS.Data;
using AMS.Contracts;
using System.Security.Claims;

namespace AMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        private readonly IUnitOfWork _unitOfWork;

        //private readonly UserManager<LoginModel> _userManager;

        public HomeController(
            //UserManager<LoginModel> userManager, 
            ILogger<HomeController> logger,
            ApplicationDbContext db,
            IUnitOfWork unitOfWork
            )
        {
            _logger = logger;
            _db = db;
            _unitOfWork = unitOfWork;
            // _userManager = userManager;
        }

        public IActionResult Index()
        {

            ViewBag.TotalProperty = _db.Propertys.Where(x => x.isDeleted == "no").Count(x => x.Id != 0);
            ViewBag.VaccantProperty = _db.Propertys.Where(x => x.Occupied == "no" && x.isDeleted == "no").Count(x => x.Id != 0);
            ViewBag.OccupiedProperty = _db.Propertys.Where(x => x.Occupied == "yes" && x.isDeleted == "no").Count(x => x.Id != 0);
            ViewBag.UnpaidInvoices = _db.Invoices.Where(x => x.isPaid == "no" && x.isDeleted == "no").Count(x => x.Id != 0);

            return View();
        }

        public IActionResult EmployeeIndex()
        {
            ViewBag.Invoice = _db.Invoices.Where(x => x.isDeleted == "no").Count(x => x.Id != 0);
            ViewBag.Maintenance = _db.Maintenances.Where(x => x.isDeleted == "no").Count(x => x.Id != 0);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Safe(int id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId

            Console.WriteLine(userId);

            //await _sms.SendSms("Accepted", "+27648917189");
            //  Emegency model = new Emegency();
            //   model.Customer.Id = userId;
            //   model.Property.Id = 1;
            //    model.Solved = "no";
            //    model.Date = DateTime.Now.Date.ToString();
            //   model.Time = DateTime.Now.TimeOfDay.ToString();
            //   await _unitOfWork.Emegencys.Create(model);    
            //   await _unitOfWork.Save();

            return RedirectToAction(nameof(Emegency));
        }
        public IActionResult Emegency()
        {
            return View();
        }

    }
}
