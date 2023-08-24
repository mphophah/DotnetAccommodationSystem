using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class StuffRepository : IStuffRepository
    {
        private readonly ApplicationDbContext _db;

        public StuffRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Stuff entity)
        {
            await _db.Stuffs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Stuff entity)
        {
            _db.Stuffs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Stuff>> FindAll()
        {
            var tenants = await _db.Stuffs.ToListAsync();
            return tenants;
        }

        public Task<Stuff> FindById(int id)
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

        public async Task<bool> Update(Stuff entity)
        {
            _db.Stuffs.Update(entity);
            return await Save();
        }
    }

}
