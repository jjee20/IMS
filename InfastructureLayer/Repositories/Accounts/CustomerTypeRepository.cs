using DomainLayer.Models.Accounts;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories.Inventory;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class CustomerTypeRepository : BaseRepository, ICustomerTypeRepository
    public class CustomerTypeRepository : Repository<CustomerType>, ICustomerTypeRepository
    {
        private ApplicationDataContext _db;
        public CustomerTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CustomerType obj)
        {
            _db.CustomerType.Update(obj);
        }
    }
}
