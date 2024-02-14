using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ICustomerTypeRepository : IRepository<CustomerType>
    {
        void Update(CustomerType obj);
    }
}