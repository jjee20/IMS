using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IVendorRepository : IRepository<Vendor>
    {
        void Update(Vendor obj);
    }
}