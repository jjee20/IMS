using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
