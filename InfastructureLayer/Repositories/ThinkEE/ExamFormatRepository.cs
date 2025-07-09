using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ExamFormatRepository : BaseRepository, IExamFormatRepository
    public class ExamFormatRepository : Repository<ExamFormat>, IExamFormatRepository
    {
        private ApplicationDataContext _db;
        public ExamFormatRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
