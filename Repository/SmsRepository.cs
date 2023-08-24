using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class SmsRepository : ISmsRepository
    {
        private readonly ApplicationDbContext _db;

        public SmsRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Sms entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Sms entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Sms>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Sms> FindById(int id)
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

        public Task<bool> Update(Sms entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
