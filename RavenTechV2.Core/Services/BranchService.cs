using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class BranchService : Repository<Branch>, IBranchService
{
    private ErpDbContext _db;
    public BranchService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IBranchService : IRepository<Branch>
{
}