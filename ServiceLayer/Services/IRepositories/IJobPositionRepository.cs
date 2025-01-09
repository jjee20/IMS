using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IJobPositionRepository : IRepository<JobPosition>
    {
        void Update(JobPosition obj);
    }
}