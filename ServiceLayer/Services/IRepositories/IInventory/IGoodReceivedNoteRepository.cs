using DomainLayer.Models.Inventory;

namespace ServiceLayer.Services.IRepositories.IInventory
{
    public interface IGoodsReceivedNoteRepository : IRepository<GoodsReceivedNote>
    {
        void Update(GoodsReceivedNote obj);
    }
}