using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
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
