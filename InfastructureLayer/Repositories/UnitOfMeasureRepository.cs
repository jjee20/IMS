using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class UnitOfMeasureRepository : BaseRepository, IUnitOfMeasureRepository
    public class UnitOfMeasureRepository : Repository<UnitOfMeasure>, IUnitOfMeasureRepository
    {
        private ApplicationDataContext _db;
        public UnitOfMeasureRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(UnitOfMeasure obj)
        {
            _db.UnitOfMeasure.Update(obj);
        }
    }
}
