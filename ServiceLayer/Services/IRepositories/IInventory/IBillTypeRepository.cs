using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IBillTypeRepository : IRepository<BillType>
    {
        void Update(BillType obj);
    }
}