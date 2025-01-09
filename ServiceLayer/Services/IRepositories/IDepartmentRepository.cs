using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        void Update(Department obj);
    }
}