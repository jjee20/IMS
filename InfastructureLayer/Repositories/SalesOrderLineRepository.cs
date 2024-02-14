using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class SalesOrderLineRepository : BaseRepository, ISalesOrderLineRepository
    public class SalesOrderLineRepository : Repository<SalesOrderLine>, ISalesOrderLineRepository
    {
        private ApplicationDataContext _db;
        public SalesOrderLineRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SalesOrderLine obj)
        {
            _db.SalesOrderLine.Update(obj);
        }
    }
}
