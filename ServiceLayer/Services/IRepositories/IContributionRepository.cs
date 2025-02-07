using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IContributionRepository : IRepository<Contribution>
    {
        void Update(Contribution obj);
    }
}