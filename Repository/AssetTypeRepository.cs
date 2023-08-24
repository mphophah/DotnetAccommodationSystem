using System.Collections.Generic;
using System.Threading.Tasks;
using AMS.Contracts;
using AMS.Data;
using Microsoft.EntityFrameworkCore;

namespace AMS.Repository
{
    public class AssetTypeRepository : IAssetTypeRepository
    {
        private readonly ApplicationDbContext _db;

        public AssetTypeRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public Task<bool> Create(AssetType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> Delete(AssetType entity)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<AssetType>> FindAll()
        {
            throw new System.NotImplementedException();
        }

        public Task<AssetType> FindById(int id)
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

        public Task<bool> Update(AssetType entity)
        {
            throw new System.NotImplementedException();
        }
    }

}
