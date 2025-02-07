using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class VendorTypeRepository : BaseRepository, IVendorTypeRepository
    public class VendorTypeRepository : Repository<VendorType>, IVendorTypeRepository
    {
        private ApplicationDataContext _db;
        public VendorTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(VendorType obj)
        {
            _db.VendorType.Update(obj);
        }
    }
}
