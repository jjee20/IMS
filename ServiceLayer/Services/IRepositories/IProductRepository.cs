using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IProductRepository : IRepository<Product>
    {
        void Update(Product obj);
    }
}