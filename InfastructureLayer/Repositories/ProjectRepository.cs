using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ProjectRepository : BaseRepository, IProjectRepository
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private ApplicationDataContext _db;
        public ProjectRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Project obj)
        {
            _db.Projects.Update(obj);
        }
    }
}
