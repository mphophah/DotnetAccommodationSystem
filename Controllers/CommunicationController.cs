using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace AMS.Controllers
{

    //[Authorize(Roles ="Administrator")]
    public class CommunicationController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly UserManager<Employee> _userManager;

        public CommunicationController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                IWebHostEnvironment webHostEnvironment,
                UserManager<Employee> userManager

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _userManager = userManager;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        // GET: AssetType
        public async Task<ActionResult> Ticket()
        {
            var communications = await _unitOfWork.Communications.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<Communication>, List<CommunicationVM>>(communications.ToList());
            return View(model);
        }
        public async Task<ActionResult> Email()
        {
            var communications = await _unitOfWork.Emails.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<Email>, List<EmailVM>>(communications.ToList());
            return View(model);
        }
        public async Task<ActionResult> Sms()
        {
            var communications = await _unitOfWork.Sms.FindAll(q => q.isDeleted == "no");
            var model = _mapper.Map<List<Sms>, List<SmsVM>>(communications.ToList());
            return View(model);
        }

        // GET: Customer/Create
        public IActionResult CreateEmail()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> CreateEmail(EmailVM model)
        {
            try
            {
                model.Process = "pending";
                var communication = _mapper.Map<Email>(model);

                communication.isDeleted = "no";
                communication.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Emails.Create(communication);

                await _unitOfWork.Save();

                return RedirectToAction("Email");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }
        // GET: Customer/Create
        public IActionResult CreateSms()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> CreateSms(SmsVM model)
        {
            try
            {
                model.Process = "pending";
                var communication = _mapper.Map<Sms>(model);

                communication.isDeleted = "no";
                communication.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Sms.Create(communication);

                await _unitOfWork.Save();

                return RedirectToAction("Sms");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> Create(CommunicationVM model)
        {
            try
            {
                model.Process = "pending";
                var communication = _mapper.Map<Communication>(model);

                communication.isDeleted = "no";
                communication.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Communications.Create(communication);

                await _unitOfWork.Save();

                return RedirectToAction("Ticket");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var isExists = await _unitOfWork.Communications.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var communication = await _unitOfWork.Communications.Find(q => q.Id == id);
            var model = _mapper.Map<CommunicationVM>(communication); //changed from customerVm
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CommunicationVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                model.Process = "updated";
                var communication = _mapper.Map<Communication>(model);
                communication.isDeleted = "no";
                _unitOfWork.Communications.Update(communication);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Ticket));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var communication = await _unitOfWork.Communications.Find(expression: q => q.Id == id);
                if (communication == null)
                {
                    return NotFound();
                }
                communication.isDeleted = "yes";
                communication.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Communications.Update(communication);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Ticket));
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Communications.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var communication = await _unitOfWork.Communications.Find(q => q.Id == id);
            var model = _mapper.Map<CommunicationVM>(communication);
            return View(model);
        }
        //*********************************************************tanent page************************************************
        // GET: AssetType TENANTS Tenant
        public async Task<ActionResult> TenantIndex()
        {
            Employee usr = await GetCurrentUserAsync();
            int link = int.Parse(usr.IntrestingKey);

            var dsd = _db.Communications
                .Where(x => x.TenantId == link.ToString() && x.isDeleted == "no")
                .ToList();

            //var communications = await _unitOfWork.Communications.FindAll();
            var model = _mapper.Map<List<Communication>, List<CommunicationVM>>(dsd);
            return View(model);
        }


        // GET: Customer/Create
        public IActionResult TenantCreate()
        {
            return View();
        }

        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> TenantCreate(CommunicationVM model)
        {
            try
            {
                Employee usr = await GetCurrentUserAsync();
                string link = usr.IntrestingKey;
                var communication = _mapper.Map<Communication>(model);
                communication.isDeleted = "no";
                communication.TenantId = link;
                await _unitOfWork.Communications.Create(communication);

                await _unitOfWork.Save();

                return RedirectToAction("TenantIndex");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

        // GET: Customer/Edit/5
        public async Task<ActionResult> TenantEdit(int id)
        {
            var isExists = await _unitOfWork.Communications.isExists(q => q.Id == id);

            if (!isExists)
            {
                return NotFound();
            }



            var communication = await _unitOfWork.Communications.Find(q => q.Id == id);
            var model = _mapper.Map<CommunicationVM>(communication); //changed from customerVm
            return View(model);
        }

        // POST: Customer/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TenantEdit(CommunicationVM model)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                var communication = _mapper.Map<Communication>(model);
                _unitOfWork.Communications.Update(communication);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(TenantIndex));
            }
            catch
            {
                ModelState.AddModelError("", "Something Went Wrong...");
                return View(model);
            }
        }

        // POST: Customer/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> TenantDelete(int id)
        {
            try
            {
                var communication = await _unitOfWork.Communications.Find(expression: q => q.Id == id);
                if (communication == null)
                {
                    return NotFound();
                }
                communication.isDeleted = "yes";
                communication.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Communications.Update(communication);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(TenantIndex));
        }

        // GET: Customer/Details/5
        public async Task<ActionResult> TenantDetails(int id)
        {
            var isExists = await _unitOfWork.Communications.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var communication = await _unitOfWork.Communications.Find(q => q.Id == id);
            var model = _mapper.Map<CommunicationVM>(communication);
            return View(model);
        }


    }
}
