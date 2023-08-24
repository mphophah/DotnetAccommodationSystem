using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly ApplicationDbContext _db;

        public SalaryRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Salary entity)
        {
            await _db.Salarys.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Salary entity)
        {
            _db.Salarys.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Salary>> FindAll()
        {
             var invoices = await _db.Salarys.ToListAsync();
             return invoices;
        }

        public Task<Salary> FindById(int id)
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

        public async Task<bool> Update(Salary entity)
        {
            _db.Salarys.Update(entity);
            return await Save();
        }
    }

}
