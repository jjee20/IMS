using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ProductPullOutLogRepository : BaseRepository, IProductPullOutLogRepository
    public class ProductPullOutLogLinesRepository : Repository<ProductPullOutLogLines>, IProductPullOutLogLinesRepository
    {
        private ApplicationDataContext _db;
        public ProductPullOutLogLinesRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
