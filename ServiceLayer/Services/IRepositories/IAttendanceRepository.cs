using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAttendanceRepository : IRepository<Attendance>
    {
        void Update(Attendance obj);
    }
}