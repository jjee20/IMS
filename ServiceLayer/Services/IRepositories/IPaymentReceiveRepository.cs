using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPaymentReceiveRepository : IRepository<PaymentReceive>
    {
        void Update(PaymentReceive obj);
    }
}