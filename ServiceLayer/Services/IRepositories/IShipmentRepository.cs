using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IShipmentRepository : IRepository<Shipment>
    {
        void Update(Shipment obj);
    }
}