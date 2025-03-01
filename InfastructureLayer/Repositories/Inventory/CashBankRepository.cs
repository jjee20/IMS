using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class CashBankRepository : BaseRepository, ICashBankRepository
    public class CashBankRepository : Repository<CashBank>, ICashBankRepository
    {
        private ApplicationDataContext _db;
        public CashBankRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CashBank obj)
        {
            _db.CashBank.Update(obj);
        }
    }
}
