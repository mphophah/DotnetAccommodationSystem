using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class EmegencyRepository : IEmegencyRepository
    {
        private readonly ApplicationDbContext _db;

        public EmegencyRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Emegency entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Emegency entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Emegency>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Emegency> FindById(int id)
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

        public Task<bool> Update(Emegency entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
