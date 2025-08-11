using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Inventory.ViewModels;
using RavenTechV2.Core.Models.MasterData;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class WarehouseService : Repository<Warehouse>, IWarehouseService
{
    private ErpDbContext _db;
    public WarehouseService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IWarehouseService : IRepository<Warehouse>
{
}