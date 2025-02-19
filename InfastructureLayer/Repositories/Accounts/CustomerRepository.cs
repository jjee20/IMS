using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories.Inventory;
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

        public void Update(Customer obj)
        {
            _db.Customer.Update(obj);
        }
    }
}
