using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;

namespace RavenTechV2.Core.Services;
public class ProductService : Repository<Product>, IProductService
{
    private ErpDbContext _db;
    public ProductService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IProductService : IRepository<Product>
{
}