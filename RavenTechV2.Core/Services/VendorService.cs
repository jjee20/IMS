using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Purchasing;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class VendorService : Repository<Vendor>, IVendorService
{
    private ErpDbContext _db;
    public VendorService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IVendorService : IRepository<Vendor>
{
}