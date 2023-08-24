using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class AssetRepository : IAssetRepository
    {
        private readonly ApplicationDbContext _db;

        public AssetRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(Asset entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(Asset entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Asset>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<Asset> FindById(int id)
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

        public Task<bool> Update(Asset entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
