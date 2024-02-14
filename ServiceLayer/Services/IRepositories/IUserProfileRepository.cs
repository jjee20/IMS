using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        void Update(UserProfile obj);
    }
}