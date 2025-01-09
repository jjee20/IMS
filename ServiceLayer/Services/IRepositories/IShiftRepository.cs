using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IShiftRepository : IRepository<Shift>
    {
        void Update(Shift obj);
    }
}