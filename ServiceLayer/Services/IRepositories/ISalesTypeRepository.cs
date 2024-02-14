using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface ISalesTypeRepository : IRepository<SalesType>
    {
        void Update(SalesType obj);
    }
}