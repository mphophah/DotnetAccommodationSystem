using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class TimesheetRepository : ITimesheetRepository
    {
        private readonly ApplicationDbContext _db;

        public TimesheetRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Timesheet entity)
        {
            await _db.Timesheets.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Timesheet entity)
        {
            _db.Timesheets.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Timesheet>> FindAll()
        {
            var invoices = await _db.Timesheets.ToListAsync();
            return invoices;
        }

        public Task<Timesheet> FindById(int id)
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

        public async Task<bool> Update(Timesheet entity)
        {
            _db.Timesheets.Update(entity);
            return await Save();
        }
    }

}
