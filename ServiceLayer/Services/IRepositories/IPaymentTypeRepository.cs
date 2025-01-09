using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        void Update(PaymentType obj);
    }
}