using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ShipmentTypeRepository : BaseRepository, IShipmentTypeRepository
    public class ShipmentTypeRepository : Repository<ShipmentType>, IShipmentTypeRepository
    {
        private ApplicationDataContext _db;
        public ShipmentTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
