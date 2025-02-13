using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IInvoiceTypeRepository : IRepository<InvoiceType>
    {
        void Update(InvoiceType obj);
    }
}