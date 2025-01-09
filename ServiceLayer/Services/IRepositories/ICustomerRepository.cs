using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
    }
}