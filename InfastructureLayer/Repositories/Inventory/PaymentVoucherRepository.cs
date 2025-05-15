using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class BillRepository : BaseRepository, IBillRepository
    public class PaymentVoucherRepository : Repository<PaymentVoucher>, IPaymentVoucherRepository
    {
        private ApplicationDataContext _db;
        public PaymentVoucherRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
