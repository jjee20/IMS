using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ISalesOrderLineRepository : IRepository<SalesOrderLine>
    {
        void Update(SalesOrderLine obj);
    }
}