using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class MaintenanceTypeRepository : IMaintenanceTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public MaintenanceTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(MaintenanceType entity)
        {
            await _db.MaintenanceTypes.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(MaintenanceType entity)
        {
            _db.MaintenanceTypes.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<MaintenanceType>> FindAll()
        {
             var maintenanceTypes = await _db.MaintenanceTypes.ToListAsync();
             return maintenanceTypes;
        }

        public Task<MaintenanceType> FindById(int id)
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

        public async Task<bool> Update(MaintenanceType entity)
        {
            _db.MaintenanceTypes.Update(entity);
            return await Save();
        }
    }

}
