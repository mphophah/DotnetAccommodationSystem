using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDbContext _db;

        public PropertyRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Property entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Property entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Property>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Property> FindById(int id)
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

        public Task<bool> Update(Property entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
