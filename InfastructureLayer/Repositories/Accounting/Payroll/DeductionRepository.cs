using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class DeductionRepository : BaseRepository, IDeductionRepository
    public class DeductionRepository : Repository<Deduction>, IDeductionRepository
    {
        private ApplicationDataContext _db;
        public DeductionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Deduction obj)
        {
            _db.Deductions.Update(obj);
        }
    }
}
