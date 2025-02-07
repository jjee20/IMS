using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface ITaxRepository : IRepository<Tax>
    {
        void Update(Tax obj);
    }
}