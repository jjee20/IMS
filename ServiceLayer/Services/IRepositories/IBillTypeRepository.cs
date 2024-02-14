using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IBillTypeRepository : IRepository<BillType>
    {
        void Update(BillType obj);
    }
}