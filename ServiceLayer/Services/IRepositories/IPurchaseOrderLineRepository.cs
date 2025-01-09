using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPurchaseOrderLineRepository : IRepository<PurchaseOrderLine>
    {
        void Update(PurchaseOrderLine obj);
    }
}