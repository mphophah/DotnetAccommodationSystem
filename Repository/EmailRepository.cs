using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly ApplicationDbContext _db;

        public EmailRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Email entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Email entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Email>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Email> FindById(int id)
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

        public Task<bool> Update(Email entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
