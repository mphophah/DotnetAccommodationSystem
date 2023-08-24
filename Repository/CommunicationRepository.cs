using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class CommunicationRepository : ICommunicationRepository
    {
        private readonly ApplicationDbContext _db;

        public CommunicationRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Communication entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Communication entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Communication>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Communication> FindById(int id)
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

        public Task<bool> Update(Communication entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
