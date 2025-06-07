using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class WarehouseRepository : BaseRepository, IWarehouseRepository
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        private ApplicationDataContext _db;
        public WarehouseRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
