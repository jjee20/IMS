using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class PurchaseTypeRepository : BaseRepository, IPurchaseTypeRepository
    public class PurchaseTypeRepository : Repository<PurchaseType>, IPurchaseTypeRepository
    {
        private ApplicationDataContext _db;
        public PurchaseTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
