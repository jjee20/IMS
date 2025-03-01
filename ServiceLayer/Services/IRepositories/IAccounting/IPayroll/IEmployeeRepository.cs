using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
        void Update(Employee obj);
    }
}