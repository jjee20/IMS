using DomainLayer.Models.Accounts;

namespace ServiceLayer.Services.IRepositories.IAccounts
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser obj);
    }
}