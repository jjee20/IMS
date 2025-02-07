using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IProductTypeRepository : IRepository<ProductType>
    {
        void Update(ProductType obj);
    }
}