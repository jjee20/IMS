using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
