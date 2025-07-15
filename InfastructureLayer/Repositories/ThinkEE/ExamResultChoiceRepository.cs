using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ExamResultChoiceRepository : BaseRepository, IExamResultChoiceRepository
    public class ExamResultChoiceRepository : Repository<ExamResultChoice>, IExamResultChoiceRepository
    {
        private ApplicationDataContext _db;
        public ExamResultChoiceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
