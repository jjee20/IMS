using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IBenefitRepository : IRepository<Benefit>
    {
        void Update(Benefit obj);
    }
}