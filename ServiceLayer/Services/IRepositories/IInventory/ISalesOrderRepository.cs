using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface ISalesOrderRepository : IRepository<SalesOrder>
    {
        void Update(SalesOrder obj);
    }
}