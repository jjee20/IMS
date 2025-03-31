using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class AllowanceRepository : BaseRepository, IAllowanceRepository
    public class AllowanceRepository : Repository<Allowance>, IAllowanceRepository
    {
        private ApplicationDataContext _db;
        public AllowanceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Allowance obj)
        {
            _db.Allowances.Update(obj);
        }
    }
}
