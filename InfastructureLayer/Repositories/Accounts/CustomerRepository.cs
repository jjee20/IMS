using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class CustomerRepository : BaseRepository, ICustomerRepository
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private ApplicationDataContext _db;
        public CustomerRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
