using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class TaxRepository : BaseRepository, ITaxRepository
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        private ApplicationDataContext _db;
        public TaxRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Tax obj)
        {
            _db.Taxes.Update(obj);
        }
    }
}
