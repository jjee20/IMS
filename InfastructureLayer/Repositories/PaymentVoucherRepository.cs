using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BillRepository : BaseRepository, IBillRepository
    public class PaymentVoucherRepository : Repository<PaymentVoucher>, IPaymentVoucherRepository
    {
        private ApplicationDataContext _db;
        public PaymentVoucherRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(PaymentVoucher obj)
        {
            _db.PaymentVoucher.Update(obj);
        }
    }
}
