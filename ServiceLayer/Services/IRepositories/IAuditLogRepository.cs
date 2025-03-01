using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        void Update(AuditLog obj);
    }
}