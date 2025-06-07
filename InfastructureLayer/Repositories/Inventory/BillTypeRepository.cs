using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class BillTypeRepository : BaseRepository, IBillTypeRepository
    public class BillTypeRepository : Repository<BillType>, IBillTypeRepository
    {
        private ApplicationDataContext _db;
        public BillTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
