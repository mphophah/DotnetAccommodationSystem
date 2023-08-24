using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class VisitorRepository : IVisitorRepository
    {
        private readonly ApplicationDbContext _db;

        public VisitorRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Visitor entity)
        {
            await _db.Visitors.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Visitor entity)
        {
            _db.Visitors.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Visitor>> FindAll()
        {
             var visitors = await _db.Visitors.ToListAsync();
             return visitors;
        }

        public Task<Visitor> FindById(int id)
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

        public async Task<bool> Update(Visitor entity)
        {
            _db.Visitors.Update(entity);
            return await Save();
        }
    }

}
