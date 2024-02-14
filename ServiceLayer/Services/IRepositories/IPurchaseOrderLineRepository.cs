using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPurchaseOrderLineRepository : IRepository<PurchaseOrderLine>
    {
        void Update(PurchaseOrderLine obj);
    }
}