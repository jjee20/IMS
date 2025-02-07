using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAllowanceRepository : IRepository<Allowance>
    {
        void Update(Allowance obj);
    }
}