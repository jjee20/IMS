using DomainLayer.Models.Accounts;

namespace ServiceLayer.Services.IRepositories.IAccounts
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        void Update(Customer obj);
    }
}