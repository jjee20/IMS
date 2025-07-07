using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ReviewTopicRepository : BaseRepository, IReviewTopicRepository
    public class ReviewTopicRepository : Repository<ReviewTopic>, IReviewTopicRepository
    {
        private ApplicationDataContext _db;
        public ReviewTopicRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
