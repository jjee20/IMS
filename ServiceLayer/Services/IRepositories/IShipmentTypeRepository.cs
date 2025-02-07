using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IShipmentTypeRepository : IRepository<ShipmentType>
    {
        void Update(ShipmentType obj);
    }
}