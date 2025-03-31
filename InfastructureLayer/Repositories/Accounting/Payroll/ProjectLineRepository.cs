using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class ProjectLineRepository : BaseRepository, IProjectLineRepository
    public class ProjectLineRepository : Repository<ProjectLine>, IProjectLineRepository
    {
        private ApplicationDataContext _db;
        public ProjectLineRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProjectLine obj)
        {
            _db.ProjectLines.Update(obj);
        }
    }
}
