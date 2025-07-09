using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class QuestionRepository : BaseRepository, IQuestionRepository
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private ApplicationDataContext _db;
        public QuestionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
