using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class CurrencyRepository : BaseRepository, ICurrencyRepository
    public class CurrencyRepository : Repository<Currency>, ICurrencyRepository
    {
        private ApplicationDataContext _db;
        public CurrencyRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Currency obj)
        {
            _db.Currency.Update(obj);
        }
    }
}
