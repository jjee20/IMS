using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface ICashBankRepository : IRepository<CashBank>
    {
        void Update(CashBank obj);
    }
}