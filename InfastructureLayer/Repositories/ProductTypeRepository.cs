using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ProductTypeRepository : BaseRepository, IProductTypeRepository
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private ApplicationDataContext _db;
        public ProductTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ProductType obj)
        {
            _db.ProductType.Update(obj);
        }
    }
}
