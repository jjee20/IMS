using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using RavenTech_ThinkEE;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ExamRepository : BaseRepository, IExamRepository
    public class ExamRepository : Repository<Exam>, IExamRepository
    {
        private readonly ApplicationDataContext _db;
        public ExamRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
