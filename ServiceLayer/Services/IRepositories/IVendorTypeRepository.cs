using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IVendorTypeRepository : IRepository<VendorType>
    {
        void Update(VendorType obj);
    }
}