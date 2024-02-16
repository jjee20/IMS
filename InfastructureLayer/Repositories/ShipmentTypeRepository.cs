using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ShipmentTypeRepository : BaseRepository, IShipmentTypeRepository
    public class ShipmentTypeRepository : Repository<ShipmentType>, IShipmentTypeRepository
    {
        private ApplicationDataContext _db;
        public ShipmentTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ShipmentType obj)
        {
            _db.ChangeTracker.Clear();
            _db.ShipmentType.Update(obj);
        }
    }
}
