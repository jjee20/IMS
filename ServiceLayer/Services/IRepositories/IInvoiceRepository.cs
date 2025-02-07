using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        void Update(Invoice obj);
    }
}