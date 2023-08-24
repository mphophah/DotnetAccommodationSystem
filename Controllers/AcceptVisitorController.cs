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
    public class AcceptVisitorController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        private readonly ISmsPortalToken _sms;
        private readonly UserManager<Employee> _userManager;

        public AcceptVisitorController(
                IMapper mapper,
                ApplicationDbContext db,
                UserManager<Employee> userManager
                )
        {
            _mapper = mapper;
            _db = db;
            _userManager = userManager;
        }

        private Task<Employee> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        [Authorize(Roles = "Employee")]
        public async Task<ActionResult> Index()
        {
            Employee usr = await GetCurrentUserAsync();
            int link = int.Parse(usr.IntrestingKey);
            // var Loans = await _unitOfWork.Loans.FindAll();
            return View(await _db.Visitors
                .Include(x => x.Customer)
                .Include(x => x.Property)
                .Where(x => x.CustomerId == link && x.isDeleted == "no")
                .ToListAsync());
        }

        public async Task<ActionResult> Accept(int id)
        {
            try
            {
                var visitors = await _unitOfWork.Visitors.Find(expression: q => q.Id == id);
                if (visitors == null)
                {
                    return NotFound();
                }
                visitors.Accept = "yes";
                _unitOfWork.Visitors.Update(visitors);
                await _unitOfWork.Save();
                //await _sms.SendSms("Yes", "+27648917189");
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> Decline(int id)
        {
            try
            {
                var visitors = await _unitOfWork.Visitors.Find(expression: q => q.Id == id);
                if (visitors == null)
                {
                    return NotFound();
                }
                visitors.Accept = "no";
                _unitOfWork.Visitors.Update(visitors);
                await _unitOfWork.Save();
                //await _sms.SendSms("No", "+27648917189");
            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

    }
}
