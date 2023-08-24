using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class AuditRepository : IAuditRepository
    {
        private readonly ApplicationDbContext _db;

        public AuditRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Audit entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Audit entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Audit>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Audit> FindById(int id)
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

        public Task<bool> Update(Audit entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
