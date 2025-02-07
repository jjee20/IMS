using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface ILeaveRepository : IRepository<Leave>
    {
        void Update(Leave obj);
    }
}