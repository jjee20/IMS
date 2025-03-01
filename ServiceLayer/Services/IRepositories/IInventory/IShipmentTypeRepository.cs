using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IShipmentTypeRepository : IRepository<ShipmentType>
    {
        void Update(ShipmentType obj);
    }
}