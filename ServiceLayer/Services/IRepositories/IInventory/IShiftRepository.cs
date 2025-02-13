using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IShiftRepository : IRepository<Shift>
    {
        void Update(Shift obj);
    }
}