using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
