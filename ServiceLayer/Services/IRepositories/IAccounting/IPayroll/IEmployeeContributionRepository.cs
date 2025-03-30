using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IEmployeeContributionRepository : IRepository<EmployeeContribution>
    {
        void Update(EmployeeContribution obj);
    }
}