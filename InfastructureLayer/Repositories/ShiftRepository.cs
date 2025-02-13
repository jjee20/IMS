using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories
{
    //public class ShiftRepository : BaseRepository, IShiftRepository
    public class ShiftRepository : Repository<Shift>, IShiftRepository
    {
        private ApplicationDataContext _db;
        public ShiftRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Shift obj)
        {
            _db.Shifts.Update(obj);
        }
    }
}
