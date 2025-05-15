using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class UnitOfMeasureRepository : BaseRepository, IUnitOfMeasureRepository
    public class UnitOfMeasureRepository : Repository<UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private ApplicationDataContext _db;
        public UnitOfMeasureRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
