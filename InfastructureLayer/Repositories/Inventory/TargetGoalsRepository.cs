using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class TargetGoalsRepository : BaseRepository, ITargetGoalsRepository
    public class TargetGoalsRepository : Repository<TargetGoals>, ITargetGoalsRepository
    {
        private ApplicationDataContext _db;
        public TargetGoalsRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
