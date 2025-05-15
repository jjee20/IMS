using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ShipmentRepository : BaseRepository, IShipmentRepository
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        private ApplicationDataContext _db;
        public ShipmentRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
