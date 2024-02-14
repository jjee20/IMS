using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IBranchRepository : IRepository<Branch>
    {
        void Update(Branch obj);
    }
}