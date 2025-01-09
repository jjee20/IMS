using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface ICashBankRepository : IRepository<CashBank>
    {
        void Update(CashBank obj);
    }
}