using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
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
