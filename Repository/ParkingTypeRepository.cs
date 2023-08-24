using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class ParkingTypeRepository : IParkingTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public ParkingTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(ParkingType entity)
        {
            await _db.ParkingTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ParkingType entity)
        {
            _db.ParkingTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<ParkingType>> FindAll()
        {
             var ParkingTypes = await _db.ParkingTypes.ToListAsync();
             return ParkingTypes;
        }

        public Task<ParkingType> FindById(int id)
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

        public async Task<bool> Update(ParkingType entity)
        {
            _db.ParkingTypes.Update(entity);
            return await Save();
        }
    }

}
