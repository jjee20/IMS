using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.Inventory;
using RavenTechV2.Core.Models.Sales;

namespace RavenTechV2.Core.Services;
public class CustomerService : Repository<Customer>, ICustomerService
{
    private ErpDbContext _db;
    public CustomerService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface ICustomerService : IRepository<Customer>
{
}