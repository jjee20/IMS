using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounting.IPayroll
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        void Update(Attendance obj);
    }
}