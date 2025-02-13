using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPurchaseOrderLineRepository : IRepository<PurchaseOrderLine>
    {
        void Update(PurchaseOrderLine obj);
    }
}