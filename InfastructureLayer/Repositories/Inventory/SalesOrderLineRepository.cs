using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class SalesOrderLineRepository : BaseRepository, ISalesOrderLineRepository
    public class SalesOrderLineRepository : Repository<SalesOrderLine>, ISalesOrderLineRepository
    {
        private ApplicationDataContext _db;
        public SalesOrderLineRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
