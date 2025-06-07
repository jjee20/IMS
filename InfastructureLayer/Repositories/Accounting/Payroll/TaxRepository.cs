using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class TaxRepository : BaseRepository, ITaxRepository
    public class TaxRepository : Repository<Tax>, ITaxRepository
    {
        private ApplicationDataContext _db;
        public TaxRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
