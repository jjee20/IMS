using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class DeductionRepository : BaseRepository, IDeductionRepository
    public class DeductionRepository : Repository<Deduction>, IDeductionRepository
    {
        private ApplicationDataContext _db;
        public DeductionRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Deduction obj)
        {
            _db.Deductions.Update(obj);
        }
    }
}
