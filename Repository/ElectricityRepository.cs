using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class ElectricityRepository : IElectricityRepository
    {
        private readonly ApplicationDbContext _db;

        public ElectricityRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Electricity entity)
        {
            await _db.Electricitys.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Electricity entity)
        {
            _db.Electricitys.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Electricity>> FindAll()
        {
             var electricitys = await _db.Electricitys.ToListAsync();
             return electricitys;
        }

        public Task<Electricity> FindById(int id)
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

        public async Task<bool> Update(Electricity entity)
        {
            _db.Electricitys.Update(entity);
            return await Save();
        }
    }

}
