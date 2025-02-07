using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class PerformanceReviewRepository : BaseRepository, IPerformanceReviewRepository
    public class PerformanceReviewRepository : Repository<PerformanceReview>, IPerformanceReviewRepository
    {
        private ApplicationDataContext _db;
        public PerformanceReviewRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PerformanceReview obj)
        {
            _db.PerformanceReviews.Update(obj);
        }
    }
}
