using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IDeductionRepository : IRepository<Deduction>
    {
        void Update(Deduction obj);
    }
}