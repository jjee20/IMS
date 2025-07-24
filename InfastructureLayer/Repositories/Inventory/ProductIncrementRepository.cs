using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ProductIncrementRepository : BaseRepository, IProductIncrementRepository
    public class ProductIncrementRepository : Repository<ProductIncrements>, IProductIncrementRepository
    {
        private ApplicationDataContext _db;
        public ProductIncrementRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
