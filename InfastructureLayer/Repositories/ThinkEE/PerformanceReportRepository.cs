using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class PerformanceReportRepository : BaseRepository, IPerformanceReportRepository
    public class PerformanceReportRepository : Repository<PerformanceReport>, IPerformanceReportRepository
    {
        private ApplicationDataContext _db;
        public PerformanceReportRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
