using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class CategoryService : Repository<Category>, ICategoryService
{
    private ErpDbContext _db;
    public CategoryService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface ICategoryService : IRepository<Category>
{
}