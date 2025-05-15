using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class EmployeeContributionRepository : BaseRepository, IEmployeeContributionRepository
    public class EmployeeContributionRepository : Repository<EmployeeContribution>, IEmployeeContributionRepository
    {
        private ApplicationDataContext _db;
        public EmployeeContributionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
