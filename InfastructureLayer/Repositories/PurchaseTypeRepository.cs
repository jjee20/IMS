using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class PurchaseTypeRepository : BaseRepository, IPurchaseTypeRepository
    public class PurchaseTypeRepository : Repository<PurchaseType>, IPurchaseTypeRepository
    {
        private ApplicationDataContext _db;
        public PurchaseTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PurchaseType obj)
        {
            _db.PurchaseType.Update(obj);
        }
    }
}
