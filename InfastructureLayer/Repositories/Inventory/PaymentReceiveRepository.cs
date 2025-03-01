using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class PaymentReceiveRepository : BaseRepository, IPaymentReceiveRepository
    public class PaymentReceiveRepository : Repository<PaymentReceive>, IPaymentReceiveRepository
    {
        private ApplicationDataContext _db;
        public PaymentReceiveRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentReceive obj)
        {
            _db.PaymentReceive.Update(obj);
        }
    }
}
