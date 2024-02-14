using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class SalesTypeRepository : BaseRepository, ISalesTypeRepository
    public class SalesTypeRepository : Repository<SalesType>, ISalesTypeRepository
    {
        private ApplicationDataContext _db;
        public SalesTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(SalesType obj)
        {
            _db.SalesType.Update(obj);
        }
    }
}
