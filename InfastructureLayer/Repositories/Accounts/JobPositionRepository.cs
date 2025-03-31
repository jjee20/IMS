using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class JobPositionRepository : BaseRepository, IJobPositionRepository
    public class JobPositionRepository : Repository<JobPosition>, IJobPositionRepository
    {
        private ApplicationDataContext _db;
        public JobPositionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(JobPosition obj)
        {
            _db.JobPositions.Update(obj);
        }
    }
}
