using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories.Inventory;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class ContributionRepository : BaseRepository, IContributionRepository
    public class ContributionRepository : Repository<Contribution>, IContributionRepository
    {
        private ApplicationDataContext _db;
        public ContributionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Contribution obj)
        {
            _db.Contributions.Update(obj);
        }
    }
}
