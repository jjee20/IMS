using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories.Inventory;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class AuditLogRepository : BaseRepository, IAuditLogRepository
    public class AuditLogRepository : Repository<AuditLog>, IAuditLogRepository
    {
        private ApplicationDataContext _db;
        public AuditLogRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AuditLog obj)
        {
            _db.AuditLogs.Update(obj);
        }
    }
}
