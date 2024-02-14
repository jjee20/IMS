using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface INumberSequenceRepository : IRepository<NumberSequence>
    {
        bool Exists(int id);
        void Update(NumberSequence obj);
    }
}