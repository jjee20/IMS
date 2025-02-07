using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
