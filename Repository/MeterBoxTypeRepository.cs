using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class MeterBoxTypeRepository : IMeterBoxTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public MeterBoxTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(MeterBoxType entity)
        {
            await _db.MeterBoxTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(MeterBoxType entity)
        {
            _db.MeterBoxTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<MeterBoxType>> FindAll()
        {
             var meterBoxTypes = await _db.MeterBoxTypes.ToListAsync();
             return meterBoxTypes;
        }

        public Task<MeterBoxType> FindById(int id)
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

        public async Task<bool> Update(MeterBoxType entity)
        {
            _db.MeterBoxTypes.Update(entity);
            return await Save();
        }
    }

}
