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
    public class LoanController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public LoanController(
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
            return View(await _db.Loans
            .Include(x => x.Customer)
            .Include(x => x.LoanType)
            .Where(x => x.isDeleted == "no")
            .OrderBy(x => x.DateCreated)
            .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            var Customers = await _unitOfWork.Customers.FindAll(expression: q => q.isDeleted == "no");
            var loanTypes = await _unitOfWork.LoanTypes.FindAll(expression: q => q.isDeleted == "no");

            var CustomersD = Customers.Select(q => new SelectListItem
            {
                Text = q.FirstName + " " + q.LastName,
                Value = q.Id.ToString()
            });

            var loanTypesD = loanTypes.Select(q => new SelectListItem
            {
                Text = q.Name,
                Value = q.Id.ToString()
            });

            var model = new LoanVM
            {
                CustomerList = CustomersD,
                LoanTypeList = loanTypesD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoanVM model)
        {
            try
            {
                var loanType = await _unitOfWork.LoanTypes.Find(expression: q => q.Id == model.LoanTypeId);

                decimal totalAmount = 0;
                decimal amount = model.Amount;
                decimal interestRate = decimal.Parse(loanType.IntrestRate) / 100;

                totalAmount = amount + (interestRate * amount);

                var LoanModel = new LoanVM
                {
                    LoanTerm = model.LoanTerm,
                    Amount = model.Amount,
                    TotalAmount = totalAmount,
                    CustomerId = model.CustomerId,
                    LoanTypeId = model.LoanTypeId,

                };
                LoanModel.Status = "owing";
                Random rd = new Random();
                int rand_num = rd.Next(10000000, 90000000);
                LoanModel.LoanNumber = rand_num.ToString();
                LoanModel.RemainingAmount = LoanModel.TotalAmount.ToString();
                var loans = _mapper.Map<Loan>(LoanModel);
                loans.isDeleted = "no";
                loans.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                await _unitOfWork.Loans.Create(loans);
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
            var loanApp = await _unitOfWork.Loans.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Customer).Include(x => x.LoanType));

            var model = _mapper.Map<EditLoanVM>(loanApp);

            ViewBag.CustomerId = new SelectList(_db.Customers.Where(x => x.isDeleted == "no"), "Id", "FirstName", model.CustomerId);
            ViewBag.LoanTypeId = new SelectList(_db.LoansTypes.Where(x => x.isDeleted == "no"), "Id", "Name", model.LoanTypeId);

            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LoanVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
                // var record = await _unitOfWork.Loans.Find(q => q.Id == model.Id, includes: q => q.Include(x => x.Customer));
                //  var record = await _unitOfWork.Loans.Find(q => q.Id == model.Id);
                var loans = _mapper.Map<Loan>(model);
                loans.Status = "owing";
                loans.isDeleted = "no";
                _unitOfWork.Loans.Update(loans);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        /*  // GET: LeaveAllocation/Details/5
          public async Task<ActionResult> Details(string id)
          {

              var records = await _unitOfWork.Loans.FindAll(
                  expression: q => q.CustomerId.ToString() == id,
                  includes: q => q.Include(x => x.LeaveType));

              var allocations = _mapper.Map<List<LoanVM>>
                      (records);

              var model = new ViewAllocationsVM
              {
                  Employee = employee,
                  LeaveAllocations = allocations
              };
              return View(model);
          }
        */

        // POST: Reservation/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var loans = await _unitOfWork.Loans.Find(expression: q => q.Id == id);
                if (loans == null)
                {
                    return NotFound();
                }
                loans.isDeleted = "yes";
                loans.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.Loans.Update(loans);
                await _unitOfWork.Save();

                //audit
                //Audit audit = new Audit();
                //audit.UserId = "x";
                //audit.Action = "x";
                //audit.Date = "x";
                //await _unitOfWork.Audits.Create(audit);
                //await _unitOfWork.Save();


            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Loan/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var isExists = await _unitOfWork.Loans.isExists(q => q.Id == id);
            if (!isExists)
            {
                return NotFound();
            }
            var loans = await _unitOfWork.Loans.Find(q => q.Id == id);
            var model = _mapper.Map<LoanVM>(loans);
            return View(model);
        }

        public async Task<ActionResult> Paid(int id)
        {
            try
            {
                var loan_found = await _unitOfWork.Loans.Find(expression: q => q.Id == id);
                if (loan_found == null)
                {
                    return NotFound();
                }
                loan_found.Status = "paid";
                _unitOfWork.Loans.Update(loan_found);
                await _unitOfWork.Save();

            }
            catch
            {

            }
            return RedirectToAction(nameof(Index));
        }


    }
}
