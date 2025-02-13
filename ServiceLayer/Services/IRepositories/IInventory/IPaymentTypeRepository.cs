using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        void Update(PaymentType obj);
    }
}