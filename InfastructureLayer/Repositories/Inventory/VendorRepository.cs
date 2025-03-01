using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class VendorRepository : BaseRepository, IVendorRepository
    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {
        private ApplicationDataContext _db;
        public VendorRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Vendor obj)
        {
            _db.Vendor.Update(obj);
        }
    }
}
