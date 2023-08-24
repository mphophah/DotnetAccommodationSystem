using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using AMS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;
using AMS.Web.Services;
using Wkhtmltopdf.NetCore;

namespace AMS.Controllers
{
    [Authorize]
    public class InvoicePdfController : Controller
    {
        private readonly IPdfService<Invoice> _pdfService;
        private readonly IGeneratePdf _generatePdf;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public InvoicePdfController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                IPdfService<Invoice> pdfService, 
                IGeneratePdf generatePdf
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _pdfService = pdfService;
            _generatePdf = generatePdf;
        }

        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult> Index()
        {
            var customers = await _unitOfWork.Customers.FindAll();
            var rentTypes = await _unitOfWork.RentTypes.FindAll();

            var CustomersD = customers.Select(q => new SelectListItem
            {
                Text = q.FirstName,
                Value = q.Id.ToString()
            });

            var RentTypesD = rentTypes.Select(q => new SelectListItem
            {
                Text = q.RentTypeName,
                Value = q.Id.ToString()
            });



            var model = new InvoiceVM
            {
                CustomerList = CustomersD,
                RentTypeList = RentTypesD,
            };

            return View(model);
        }

        public IActionResult Demo()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GenerateInvoice(Invoice invoice)
        {
            return await _generatePdf.GetPdf("Views/Templates/InvoicePdf.cshtml", invoice);
        }


    }
}
