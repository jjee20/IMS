using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class PurchaseOrderLineRepository : BaseRepository, IPurchaseOrderLineRepository
    public class PurchaseOrderLineRepository : Repository<PurchaseOrderLine>, IPurchaseOrderLineRepository
    {
        private ApplicationDataContext _db;
        public PurchaseOrderLineRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
