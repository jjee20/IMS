using DomainLayer.Models.Accounts;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDataContext _db;
        public ApplicationUserRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
