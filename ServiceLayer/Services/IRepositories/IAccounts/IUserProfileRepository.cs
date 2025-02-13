using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IAccounts
{
    public interface IUserProfileRepository : IRepository<UserProfile>
    {
        void Update(UserProfile obj);
    }
}