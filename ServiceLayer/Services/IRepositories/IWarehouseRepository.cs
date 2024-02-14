using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IWarehouseRepository : IRepository<Warehouse>
    {
        void Update(Warehouse obj);
    }
}