using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class ProjectRepository : BaseRepository, IProjectRepository
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        private ApplicationDataContext _db;
        public ProjectRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
        public void UpdateProjectWithLines(Project entity)
        {
            // Assume ProjectLineId is the PK of ProjectLine.
            UpdateWithChildren<Project, ProjectLine>(
                entity,
                p => p.ProjectLines,
                pl => pl.ProjectLineId // <-- Make sure this is the correct PK for ProjectLine
            );
        }
    }
}
