using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class VendorTypeRepository : BaseRepository, IVendorTypeRepository
    public class VendorTypeRepository : Repository<VendorType>, IVendorTypeRepository
    {
        private ApplicationDataContext _db;
        public VendorTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
