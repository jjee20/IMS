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
        User = new Lazy<IUserService>(() => new UserService(_erpDbContext));
        Product = new Lazy<IProductService>(() => new ProductService(_erpDbContext));
    }

    public Lazy<IUserService> User { get; }
    public Lazy<IProductService> Product { get; }
    public Task SaveChangesAsync() => _erpDbContext.SaveChangesAsync();

}

public interface IUnitOfService
{
    Lazy<IUserService> User { get; }
    Lazy<IProductService> Product { get; }
    Task SaveChangesAsync();
}