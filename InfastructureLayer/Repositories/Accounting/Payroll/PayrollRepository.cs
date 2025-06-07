using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class PayrollRepository : BaseRepository, IPayrollRepository
    public class PayrollRepository : Repository<DomainLayer.Models.Accounting.Payroll.Payroll>, IPayrollRepository
    {
        private ApplicationDataContext _db;
        public PayrollRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
