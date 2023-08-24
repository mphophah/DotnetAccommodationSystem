using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationDbContext _db;

        public InvoiceRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public async Task<bool> Create(Invoice entity)
        {
            await _db.Invoices.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Invoice entity)
        {
            _db.Invoices.Remove(entity);
            return await Save();
        }

        public async Task<ICollection<Invoice>> FindAll()
        {
             var invoices = await _db.Invoices.ToListAsync();
             return invoices;
        }

        public Task<Invoice> FindById(int id)
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

        public async Task<bool> Update(Invoice entity)
        {
            _db.Invoices.Update(entity);
            return await Save();
        }
    }

}
