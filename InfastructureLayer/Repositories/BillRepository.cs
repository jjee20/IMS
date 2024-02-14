using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BillRepository : BaseRepository, IBillRepository
    public class BillRepository : Repository<Bill>, IBillRepository
    {
        private ApplicationDataContext _db;
        public BillRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Bill obj)
        {
            _db.Bill.Update(obj);
        }
    }
}
