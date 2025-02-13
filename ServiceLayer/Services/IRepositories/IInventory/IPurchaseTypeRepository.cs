using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPurchaseTypeRepository : IRepository<PurchaseType>
    {
        void Update(PurchaseType obj);
    }
}