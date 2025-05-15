using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ProductStockInLogRepository : BaseRepository, IProductStockInLogRepository
    public class ProductStockInLogRepository : Repository<ProductStockInLog>, IProductStockInLogRepository
    {
        private ApplicationDataContext _db;
        public ProductStockInLogRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
