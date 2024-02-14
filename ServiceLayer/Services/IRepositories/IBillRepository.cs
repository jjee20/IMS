using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IBillRepository : IRepository<Bill>
    {
        void Update(Bill obj);
    }
}