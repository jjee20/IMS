using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using InfastructureLayer.Repositories.Inventory;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounting.IPayroll;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class EmployeeRepository : BaseRepository, IEmployeeRepository
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private ApplicationDataContext _db;
        public EmployeeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Employee obj)
        {
            _db.Employees.Update(obj);
        }
    }
}
