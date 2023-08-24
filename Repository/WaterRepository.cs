using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class WaterRepository : IWaterRepository
    {
        private readonly ApplicationDbContext _db;

        public WaterRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Water entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Water entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Water>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Water> FindById(int id)
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

        public Task<bool> Update(Water entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
