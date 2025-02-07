using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ShipmentRepository : BaseRepository, IShipmentRepository
    public class ShipmentRepository : Repository<Shipment>, IShipmentRepository
    {
        private ApplicationDataContext _db;
        public ShipmentRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Shipment obj)
        {
            _db.Shipment.Update(obj);
        }
    }
}
