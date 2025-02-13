using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IContributionRepository : IRepository<Contribution>
    {
        void Update(Contribution obj);
    }
}