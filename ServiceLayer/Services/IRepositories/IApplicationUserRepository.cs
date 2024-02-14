using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        void Update(ApplicationUser user);
    }
}