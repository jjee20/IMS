using DomainLayer.Models;

namespace ServiceLayer.Services.IRepositories
{
    public interface IGoodsReceivedNoteRepository : IRepository<GoodsReceivedNote>
    {
        void Update(GoodsReceivedNote obj);
    }
}