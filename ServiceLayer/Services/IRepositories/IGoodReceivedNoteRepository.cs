using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories
{
    public interface IGoodsReceivedNoteRepository : IRepository<GoodsReceivedNote>
    {
        void Update(GoodsReceivedNote obj);
    }
}