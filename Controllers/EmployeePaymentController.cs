using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AMS.Controllers
{
    [Authorize]
    public class EmployeePaymentController : Controller
    {
        //private readonly IPdfService<Invoice> _pdfService;
        //private readonly IGeneratePdf _generatePdf;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly UserManager<Employee> _userManager;
        public EmployeePaymentController(
                IUnitOfWork unitOfWork,
                IMapper mapper,
                ApplicationDbContext db,
                UserManager<Employee> userManager
                // IPdfService<Invoice> pdfService,
                // IGeneratePdf generatePdf
                )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
            // _pdfService = pdfService;
            // _generatePdf = generatePdf;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> Index()
        {
            Employee usr = await GetCurrentUserAsync();
            int link = int.Parse(usr.IntrestingKey);
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Invoices
                .Include(x => x.Customer)
                .Include(x => x.RentType)
                .Where(x => x.CustomerId == link && x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

    }
}
