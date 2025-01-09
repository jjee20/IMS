using DomainLayer.Models.Accounts;

namespace ServiceLayer.Services.IRepositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser obj);
    }
}