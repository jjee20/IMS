using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        void Update(Vendor obj);
    }
}