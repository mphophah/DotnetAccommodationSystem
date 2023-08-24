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
    public class LoanInstallmentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public LoanInstallmentController(
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
            return View(await _db.LoanInstallments
                .Include(x => x.Loan)
                .Where(x => x.isDeleted == "no")
                .OrderBy(x => x.DateCreated)
                .ToListAsync());
        }

        // GET: Loan/Create
        public async Task<ActionResult> Create()
        {
            //var customers = await _unitOfWork.Customers.FindAll();
            var loanList = await _unitOfWork.Loans.FindAll(expression: q => q.isDeleted == "no");

            var LoanListD = loanList.Select(q => new SelectListItem
            {
                Text = q.LoanNumber,
                Value = q.Id.ToString()
            });


            var model = new LoanInstallmentVM
            {
                LoanList = LoanListD,
            };

            return View(model);
        }

        // POST: Loan/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(LoanInstallmentVM model)
        {


            try
            {
                var loan = await _unitOfWork.Loans.Find(expression: q => q.Id == model.LoanId);
                decimal calcualteRemainingAmount = 0;
                calcualteRemainingAmount = decimal.Parse(loan.RemainingAmount) - decimal.Parse(model.Amount);

                if (calcualteRemainingAmount <= 0)
                {
                    loan.Status = "paid";
                    loan.RemainingAmount = calcualteRemainingAmount.ToString();
                    _unitOfWork.Loans.Update(loan);
                    await _unitOfWork.Save();
                }
                loan.RemainingAmount = calcualteRemainingAmount.ToString();
                _unitOfWork.Loans.Update(loan);
                await _unitOfWork.Save();

                var loanInstallment_add = _mapper.Map<LoanInstallment>(model);
                loanInstallment_add.isDeleted = "no";
                loanInstallment_add.DateCreated = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                //loanInstallment_add.Remaining = calcualteRemainingAmount.ToString();
                await _unitOfWork.LoanInstallments.Create(loanInstallment_add);
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
            var meterBoxTApp = await _unitOfWork.LoanInstallments.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Loan));

            var model = _mapper.Map<EditLoanInstallmentVM>(meterBoxTApp);

            //ViewBag.LoanNumber = new SelectList(_db.Loans, "Id", "LoanNumber", model.LoanNumber);


            return View(model);
        }

        // POST: Loan/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(LoanInstallmentVM model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var LoanInstallment_add = _mapper.Map<LoanInstallment>(model);
                LoanInstallment_add.isDeleted = "no";
                _unitOfWork.LoanInstallments.Update(LoanInstallment_add);
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
                var loanInstallment_add = await _unitOfWork.LoanInstallments.Find(expression: q => q.Id == id);
                if (loanInstallment_add == null)
                {
                    return NotFound();
                }
                loanInstallment_add.isDeleted = "yes";
                loanInstallment_add.DateDeleted = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
                _unitOfWork.LoanInstallments.Update(loanInstallment_add);
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
            var loanInstallment_add = await _unitOfWork.LoanInstallments.Find(q => q.Id == id,
            includes: q => q.Include(x => x.Loan));

            var model = _mapper.Map<EditLoanInstallmentVM>(loanInstallment_add);

            // ViewBag.LoanNumber = new SelectList(_db.Loans, "Id", "LoanNumber", model.LoanNumber);


            return View(model);
        }


    }
}
