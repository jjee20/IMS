using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
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
