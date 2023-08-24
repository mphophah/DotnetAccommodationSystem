using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class MaintenanceRepository : IMaintenanceRepository
    {
        private readonly ApplicationDbContext _db;

        public MaintenanceRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Maintenance entity)
        {
            await _db.Maintenances.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Maintenance entity)
        {
            _db.Maintenances.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Maintenance>> FindAll()
        {
             var maintenances = await _db.Maintenances.ToListAsync();
             return maintenances;
        }

        public Task<Maintenance> FindById(int id)
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

        public async Task<bool> Update(Maintenance entity)
        {
            _db.Maintenances.Update(entity);
            return await Save();
        }
    }

}
