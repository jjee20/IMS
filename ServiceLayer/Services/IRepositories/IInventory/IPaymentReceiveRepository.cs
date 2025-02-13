using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPaymentReceiveRepository : IRepository<PaymentReceive>
    {
        void Update(PaymentReceive obj);
    }
}