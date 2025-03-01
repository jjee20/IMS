using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounts
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Update(Department obj);
    }
}