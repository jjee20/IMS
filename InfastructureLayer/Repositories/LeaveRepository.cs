using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class LeaveRepository : BaseRepository, ILeaveRepository
    public class LeaveRepository : Repository<Leave>, ILeaveRepository
    {
        private ApplicationDataContext _db;
        public LeaveRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Leave obj)
        {
            _db.Leaves.Update(obj);
        }
    }
}
