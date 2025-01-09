using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IUnitOfMeasureRepository : IRepository<UnitOfMeasure>
    {
        void Update(UnitOfMeasure obj);
    }
}