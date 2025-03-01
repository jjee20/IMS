using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IBillRepository : IRepository<Bill>
    {
        void Update(Bill obj);
    }
}