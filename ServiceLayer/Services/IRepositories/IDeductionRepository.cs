using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IDeductionRepository : IRepository<Deduction>
    {
        void Update(Deduction obj);
    }
}