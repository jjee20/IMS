using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface ISalesOrderLineRepository : IRepository<SalesOrderLine>
    {
        void Update(SalesOrderLine obj);
    }
}