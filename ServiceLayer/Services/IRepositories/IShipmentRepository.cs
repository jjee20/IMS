using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        void Update(Shipment obj);
    }
}