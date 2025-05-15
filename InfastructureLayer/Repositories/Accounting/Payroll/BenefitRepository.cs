using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class BenefitRepository : BaseRepository, IBenefitRepository
    public class BenefitRepository : Repository<Benefit>, IBenefitRepository
    {
        private ApplicationDataContext _db;
        public BenefitRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
