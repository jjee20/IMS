using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        void Update(Project obj);
    }
}