using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories
{
    //public class PaymentTypeRepository : BaseRepository, IPaymentTypeRepository
    public class PaymentTypeRepository : Repository<PaymentType>, IPaymentTypeRepository
    {
        private ApplicationDataContext _db;
        public PaymentTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentType obj)
        {
            _db.PaymentType.Update(obj);
        }
    }
}
