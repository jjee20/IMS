using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPurchaseTypeRepository : IRepository<PurchaseType>
    {
        void Update(PurchaseType obj);
    }
}