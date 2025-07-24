using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ExamResultRepository : BaseRepository, IExamResultRepository
    public class ExamResultRepository : Repository<ExamResult>, IExamResultRepository
    {
        private ApplicationDataContext _db;
        public ExamResultRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
