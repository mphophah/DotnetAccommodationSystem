using System;
using System.Threading.Tasks;
using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace AMS.Controllers
{


    public class AdmissionCustomerController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public AdmissionCustomerController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                IWebHostEnvironment webHostEnvironment,
                ApplicationDbContext db

                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _db = db;

        }

        // GET: Customer/Create
        public IActionResult CustomerAdmissionCreate()
        {
            return View();
        }


        //POST: Customer/Create
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<ActionResult> CustomerAdmissionCreate(CustomerVM model)
        {
            try
            {
                //model.isDeleted = "no";
                model.process = "pending";

                var tenant = _mapper.Map<Customer>(model);
                tenant.isDeleted = "no";
                tenant.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Customers.Create(tenant);

                await _unitOfWork.Save();

                return RedirectToAction("CustomerAdmissionCreate");
            }
            catch (Exception ex)
            {

                ModelState.AddModelError(ex.Message, "");
                return View();
            }

        }

    }
}
