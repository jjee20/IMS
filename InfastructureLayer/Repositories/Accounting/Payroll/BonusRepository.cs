using DomainLayer.Models.Accounting.Payroll;
using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.PayrollViewModels;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounting.Payroll
{
    //public class BonusRepository : BaseRepository, IBonusRepository
    public class BonusRepository : Repository<Bonus>, IBonusRepository
    {
        private ApplicationDataContext _db;
        public BonusRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
