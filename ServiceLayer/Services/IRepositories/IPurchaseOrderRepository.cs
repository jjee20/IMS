using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        void Update(PurchaseOrder obj);
    }
}