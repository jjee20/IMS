using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BenefitRepository : BaseRepository, IBenefitRepository
    public class BenefitRepository : Repository<Benefit>, IBenefitRepository
    {
        private ApplicationDataContext _db;
        public BenefitRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Benefit obj)
        {
            _db.Benefits.Update(obj);
        }
    }
}
