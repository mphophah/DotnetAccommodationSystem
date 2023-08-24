using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class SmsUsageRepository : ISmsUsageRepository
    {
        private readonly ApplicationDbContext _db;

        public SmsUsageRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(SmsUsage entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(SmsUsage entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<SmsUsage>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<SmsUsage> FindById(int id)
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

        public Task<bool> Update(SmsUsage entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
