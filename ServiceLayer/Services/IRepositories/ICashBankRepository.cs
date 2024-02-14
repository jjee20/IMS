using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ICashBankRepository : IRepository<CashBank>
    {
        void Update(CashBank obj);
    }
}