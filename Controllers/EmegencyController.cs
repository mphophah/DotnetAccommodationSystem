using AutoMapper;
using AMS.Contracts;
using AMS.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace AMS.Controllers
{

    [Authorize(Roles = "Administrator")]
    public class EmegencyController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _db;


        public EmegencyController(
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

        // GET: AssetType
        public async Task<ActionResult> Index()
        {

            var emegency_add = await _db.Emegencys
            .Include(x => x.Customer)
            .Include(x => x.Property)
            .Where(x => x.isDeleted == "no")
            .OrderBy(x => x.DateCreated)
            .ToListAsync();

            return View(emegency_add);
        }

        public async Task<ActionResult> Solved(int id)
        {
            try
            {
                var emegency_add = await _unitOfWork.Emegencys.Find(expression: q => q.Id == id);
                if (emegency_add == null)
                {
                    return NotFound();
                }
                emegency_add.Solved = "True";
                _unitOfWork.Emegencys.Update(emegency_add);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }


    }
}
