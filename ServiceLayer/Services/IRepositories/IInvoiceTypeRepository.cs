using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IInvoiceTypeRepository : IRepository<InvoiceType>
    {
        void Update(InvoiceType obj);
    }
}