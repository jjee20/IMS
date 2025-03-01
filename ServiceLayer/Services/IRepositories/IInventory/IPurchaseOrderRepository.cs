using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        void Update(PurchaseOrder obj);
    }
}