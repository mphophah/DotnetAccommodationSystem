using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class RentTypeRepository : IRentTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public RentTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(RentType entity)
        {
            await _db.RentTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(RentType entity)
        {
            _db.RentTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<RentType>> FindAll()
        {
             var rentTypes = await _db.RentTypes.ToListAsync();
             return rentTypes;
        }

        public Task<RentType> FindById(int id)
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

        public async Task<bool> Update(RentType entity)
        {
            _db.RentTypes.Update(entity);
            return await Save();
        }
    }

}
