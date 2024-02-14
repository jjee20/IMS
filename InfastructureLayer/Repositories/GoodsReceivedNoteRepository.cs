using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class GoodsReceivedNoteRepository : BaseRepository, IGoodsReceivedNoteRepository
    public class GoodsReceivedNoteRepository : Repository<GoodsReceivedNote>, IGoodsReceivedNoteRepository
    {
        private ApplicationDataContext _db;
        public GoodsReceivedNoteRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(GoodsReceivedNote obj)
        {
            _db.GoodsReceivedNote.Update(obj);
        }
    }
}
