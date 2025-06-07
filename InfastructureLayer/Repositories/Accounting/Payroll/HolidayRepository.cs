using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class HolidayRepository : BaseRepository, IHolidayRepository
    public class HolidayRepository : Repository<Holiday>, IHolidayRepository
    {
        private ApplicationDataContext _db;
        public HolidayRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
