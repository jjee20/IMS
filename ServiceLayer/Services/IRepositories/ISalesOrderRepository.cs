using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ISalesOrderRepository : IRepository<SalesOrder>
    {
        void Update(SalesOrder obj);
    }
}