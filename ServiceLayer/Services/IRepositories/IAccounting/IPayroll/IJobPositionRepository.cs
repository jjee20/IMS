using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IJobPositionRepository : IRepository<JobPosition>
    {
        void Update(JobPosition obj);
    }
}