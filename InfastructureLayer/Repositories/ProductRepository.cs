using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ProductRepository : BaseRepository, IProductRepository
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDataContext _db;
        public ProductRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Product obj)
        {
            _db.Product.Update(obj);
        }
    }
}
