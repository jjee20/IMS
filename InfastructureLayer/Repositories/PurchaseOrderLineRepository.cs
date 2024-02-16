using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class PurchaseOrderLineRepository : BaseRepository, IPurchaseOrderLineRepository
    public class PurchaseOrderLineRepository : Repository<PurchaseOrderLine>, IPurchaseOrderLineRepository
    {
        private ApplicationDataContext _db;
        public PurchaseOrderLineRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PurchaseOrderLine obj)
        {
            _db.ChangeTracker.Clear();
            _db.PurchaseOrderLine.Update(obj);
        }
    }
}
