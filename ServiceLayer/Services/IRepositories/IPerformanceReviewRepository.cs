using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPerformanceReviewRepository : IRepository<PerformanceReview>
    {
        void Update(PerformanceReview obj);
    }
}