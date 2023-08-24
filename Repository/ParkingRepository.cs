using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class ParkingRepository : IParkingRepository
    {
        private readonly ApplicationDbContext _db;

        public ParkingRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Parking entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Parking entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Parking>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Parking> FindById(int id)
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

        public Task<bool> Update(Parking entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
