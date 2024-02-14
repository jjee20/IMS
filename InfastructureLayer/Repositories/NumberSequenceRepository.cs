using DomainLayer.Models;
using InfastructureLayer.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class NumberSequenceRepository : BaseRepository, INumberSequenceRepository
    public class NumberSequenceRepository : Repository<NumberSequence>, INumberSequenceRepository
    {
        private ApplicationDataContext _db;
        public NumberSequenceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
        public bool Exists(int id)
        {
            return _db.NumberSequence.Any(e => e.NumberSequenceId == id);
        }
        public void Update(NumberSequence obj)
        {
            _db.Entry(obj).State = EntityState.Modified;
        }
    }
}
