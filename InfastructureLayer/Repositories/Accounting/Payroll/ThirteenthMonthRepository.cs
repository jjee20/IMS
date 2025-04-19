using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class ThirteenthMonthRepository : BaseRepository, IThirteenthMonthRepository
    public class ThirteenthMonthRepository : Repository<ThirteenthMonth>, IThirteenthMonthRepository
    {
        private ApplicationDataContext _db;
        public ThirteenthMonthRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ThirteenthMonth obj)
        {
            _db.ThirteenthMonths.Update(obj);
        }
    }
}
