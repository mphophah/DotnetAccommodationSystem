using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class PropertyTypeRepository : IPropertyTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public PropertyTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(PropertyType entity)
        {
            await _db.PropertyTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(PropertyType entity)
        {
            _db.PropertyTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<PropertyType>> FindAll()
        {
             var propertyTypes = await _db.PropertyTypes.ToListAsync();
             return propertyTypes;
        }

        public Task<PropertyType> FindById(int id)
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

        public async Task<bool> Update(PropertyType entity)
        {
            _db.PropertyTypes.Update(entity);
            return await Save();
        }
    }

}
