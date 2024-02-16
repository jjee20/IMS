using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class WarehouseRepository : BaseRepository, IWarehouseRepository
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private ApplicationDataContext _db;
        public WarehouseRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Warehouse obj)
        {
            _db.ChangeTracker.Clear();
            _db.Warehouse.Update(obj);
        }
    }
}
