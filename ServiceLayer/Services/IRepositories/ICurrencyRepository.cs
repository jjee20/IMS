using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ICurrencyRepository : IRepository<Currency>
    {
        void Update(Currency obj);
    }
}