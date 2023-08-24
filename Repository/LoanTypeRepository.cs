using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class LoanTypeRepository : GenericRepository<LoanType>, ILoanTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public LoanTypeRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }

        public Task<ICollection<LoanType>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<LoanType> FindById(int id)
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

        Task<bool> IRepositoryBase<LoanType>.Create(LoanType entity)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepositoryBase<LoanType>.Delete(LoanType entity)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepositoryBase<LoanType>.Update(LoanType entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
