using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories
{
    //public class PurchaseOrderRepository : BaseRepository, IPurchaseOrderRepository
    public class PurchaseOrderRepository : Repository<PurchaseOrder>, IPurchaseOrderRepository
    {
        private ApplicationDataContext _db;
        public PurchaseOrderRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PurchaseOrder obj)
        {
            _db.PurchaseOrder.Update(obj);
        }
    }
}
