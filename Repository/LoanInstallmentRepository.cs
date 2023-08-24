using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class LoanInstallmentRepository : ILoanInstallmentRepository
    {
        private readonly ApplicationDbContext _db;

        public LoanInstallmentRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(LoanInstallment entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(LoanInstallment entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<LoanInstallment>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<LoanInstallment> FindById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> isExists(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Update(LoanInstallment entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
