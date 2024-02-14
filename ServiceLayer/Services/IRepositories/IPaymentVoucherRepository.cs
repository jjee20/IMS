using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPaymentVoucherRepository : IRepository<PaymentVoucher>
    {
        void Update(PaymentVoucher obj);
    }
}