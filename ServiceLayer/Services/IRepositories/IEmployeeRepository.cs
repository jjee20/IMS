using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
    }
}