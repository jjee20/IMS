using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPurchaseTypeRepository : IRepository<PurchaseType>
    {
        void Update(PurchaseType obj);
    }
}