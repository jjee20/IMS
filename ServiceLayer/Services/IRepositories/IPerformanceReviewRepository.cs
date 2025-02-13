using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPerformanceReviewRepository : IRepository<PerformanceReview>
    {
        void Update(PerformanceReview obj);
    }
}