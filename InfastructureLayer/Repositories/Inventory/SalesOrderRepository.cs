using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class SalesOrderRepository : BaseRepository, ISalesOrderRepository
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        private ApplicationDataContext _db;
        public SalesOrderRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
