using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BillTypeRepository : BaseRepository, IBillTypeRepository
    public class BillTypeRepository : Repository<BillType>, IBillTypeRepository
    {
        private ApplicationDataContext _db;
        public BillTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(BillType obj)
        {
            _db.BillType.Update(obj);
        }
    }
}
