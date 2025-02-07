using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class AttendanceRepository : BaseRepository, IAttendanceRepository
    public class AttendanceRepository : Repository<Attendance>, IAttendanceRepository
    {
        private ApplicationDataContext _db;
        public AttendanceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Attendance obj)
        {
            _db.Attendances.Update(obj);
        }
    }
}
