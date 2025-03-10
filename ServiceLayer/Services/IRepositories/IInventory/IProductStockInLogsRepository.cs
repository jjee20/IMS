using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IProductStockInLogRepository : IRepository<ProductStockInLog>
    {
        void Update(ProductStockInLog obj);
    }
}