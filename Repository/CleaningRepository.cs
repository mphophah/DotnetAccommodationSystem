using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class CleaningRepository : ICleaningRepository
    {
        private readonly ApplicationDbContext _db;

        public CleaningRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Cleaning entity)
        {
            await _db.Cleanings.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Cleaning entity)
        {
            _db.Cleanings.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Cleaning>> FindAll()
        {
            var maintenances = await _db.Cleanings.ToListAsync();
            return maintenances;
        }

        public Task<Cleaning> FindById(int id)
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

        public async Task<bool> Update(Cleaning entity)
        {
            _db.Cleanings.Update(entity);
            return await Save();
        }
    }

}
