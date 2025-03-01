using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPaymentVoucherRepository : IRepository<PaymentVoucher>
    {
        void Update(PaymentVoucher obj);
    }
}