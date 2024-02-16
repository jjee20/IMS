using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class SalesOrderRepository : BaseRepository, ISalesOrderRepository
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        private ApplicationDataContext _db;
        public SalesOrderRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SalesOrder obj)
        {
            _db.ChangeTracker.Clear();
            _db.SalesOrder.Update(obj);
        }
    }
}
