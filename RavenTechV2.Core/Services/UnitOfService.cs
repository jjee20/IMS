using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Data;

namespace RavenTechV2.Core.Services;
public class UnitOfService : IUnitOfService
{
    private readonly ErpDbContext _erpDbContext;

    public UnitOfService(ErpDbContext erpDbContext)
    {
        _erpDbContext = erpDbContext;
        Category = new Lazy<ICategoryService>(() => new CategoryService(_erpDbContext));
        Warehouse = new Lazy<IWarehouseService>(() => new WarehouseService(_erpDbContext));
        User = new Lazy<IUserService>(() => new UserService(_erpDbContext));
        Product = new Lazy<IProductService>(() => new ProductService(_erpDbContext));
        Customer = new Lazy<ICustomerService>(() => new CustomerService(_erpDbContext));
        Vendor = new Lazy<IVendorService>(() => new VendorService(_erpDbContext));
        Branch = new Lazy<IBranchService>(() => new BranchService(_erpDbContext));
        UnitOfMeasure = new Lazy<IUnitOfMeasureService>(() => new UnitOfMeasureService(_erpDbContext));
    }

    public Lazy<ICategoryService> Category { get; }
    public Lazy<IWarehouseService> Warehouse { get; }
    public Lazy<IUserService> User { get; }
    public Lazy<IProductService> Product { get; }
    public Lazy<ICustomerService> Customer { get; }
    public Lazy<IVendorService> Vendor { get; }
    public Lazy<IBranchService> Branch { get; }
    public Lazy<IUnitOfMeasureService> UnitOfMeasure { get; }
    public Task SaveChangesAsync() => _erpDbContext.SaveChangesAsync();

}

public interface IUnitOfService
{
    Lazy<ICategoryService> Category { get; }
    Lazy<IWarehouseService> Warehouse { get; }
    Lazy<IUserService> User { get; }
    Lazy<IProductService> Product { get; }
    Lazy<ICustomerService> Customer { get; }
    Lazy<IVendorService> Vendor { get; }
    Lazy<IBranchService> Branch { get; }
    Lazy<IUnitOfMeasureService> UnitOfMeasure { get; }
    Task SaveChangesAsync();
}