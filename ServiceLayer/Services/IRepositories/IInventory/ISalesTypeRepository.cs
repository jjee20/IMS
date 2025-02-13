using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface ISalesTypeRepository : IRepository<SalesType>
    {
        void Update(SalesType obj);
    }
}