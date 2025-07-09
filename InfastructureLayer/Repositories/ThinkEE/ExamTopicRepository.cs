using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ExamTopicRepository : BaseRepository, IExamTopicRepository
    public class ExamTopicRepository : Repository<ExamTopic>, IExamTopicRepository
    {
        private ApplicationDataContext _db;
        public ExamTopicRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
