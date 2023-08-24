using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class AdmissionRepository : IAdmissionRepository
    {
        private readonly ApplicationDbContext _db;

        public AdmissionRepository(ApplicationDbContext db)
        {
            _db = db;

        }
        public Task<bool> Create(Admission entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Admission entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Admission>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Admission> FindById(int id)
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

        public Task<bool> Update(Admission entity)
        {
            throw new System.NotImplementedException();
        }

    }

}
