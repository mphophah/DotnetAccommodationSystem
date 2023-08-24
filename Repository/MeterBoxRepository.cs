using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class MeterBoxRepository : IMeterBoxRepository
    {
        private readonly ApplicationDbContext _db;

        public MeterBoxRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(MeterBox entity)
        {
            await _db.MeterBoxs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(MeterBox entity)
        {
            _db.MeterBoxs.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<MeterBox>> FindAll()
        {
             var meterBoxs = await _db.MeterBoxs.ToListAsync();
             return meterBoxs;
        }

        public Task<MeterBox> FindById(int id)
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

        public async Task<bool> Update(MeterBox entity)
        {
            _db.MeterBoxs.Update(entity);
            return await Save();
        }
    }

}
