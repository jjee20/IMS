using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IBenefitRepository : IRepository<Benefit>
    {
        void Update(Benefit obj);
    }
}