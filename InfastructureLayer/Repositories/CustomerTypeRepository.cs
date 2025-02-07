using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
