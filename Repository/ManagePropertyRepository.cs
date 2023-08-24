using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class ManagePropertyRepository : IManagePropertyRepository
    {
        private readonly ApplicationDbContext _db;

        public ManagePropertyRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(ManageProperty entity)
        {
            await _db.ManagePropertys.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(ManageProperty entity)
        {
            _db.ManagePropertys.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<ManageProperty>> FindAll()
        {
             var managePropertys = await _db.ManagePropertys.ToListAsync();
             return managePropertys;
        }

        public Task<ManageProperty> FindById(int id)
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

        public async Task<bool> Update(ManageProperty entity)
        {
            _db.ManagePropertys.Update(entity);
            return await Save();
        }
    }

}
