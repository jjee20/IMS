using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;

namespace ServiceLayer.Services.IRepositories
{
    public interface IAuditLogRepository : IRepository<AuditLog>
    {
        void Update(AuditLog obj);
    }
}