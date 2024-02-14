using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}