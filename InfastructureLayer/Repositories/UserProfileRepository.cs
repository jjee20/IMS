using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class UserProfileRepository : BaseRepository, IUserProfileRepository
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        private ApplicationDataContext _db;
        public UserProfileRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UserProfile obj)
        {
            _db.ChangeTracker.Clear();
            _db.UserProfile.Update(obj);
        }
    }
}
