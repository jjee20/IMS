using DomainLayer.Models.Inventory;
using DomainLayer.Models.ThinkEE;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories.IThinkEE;

namespace InfastructureLayer.Repositories.ThinkEE
{
    //public class ChoiceRepository : BaseRepository, IChoiceRepository
    public class ChoiceRepository : Repository<Choice>, IChoiceRepository
    {
        private ApplicationDataContext _db;
        public ChoiceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
