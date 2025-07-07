using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounts
{
    public interface IProjectRepository : IRepository<Project>
    {
        void UpdateProjectWithLines(Project entity);
    }
}