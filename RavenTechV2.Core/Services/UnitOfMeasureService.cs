using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class UnitOfMeasureService : Repository<UnitOfMeasure>, IUnitOfMeasureService
{
    private ErpDbContext _db;
    public UnitOfMeasureService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IUnitOfMeasureService : IRepository<UnitOfMeasure>
{
}