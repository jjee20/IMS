using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories
{
    //public class DepartmentRepository : BaseRepository, IDepartmentRepository
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private ApplicationDataContext _db;
        public DepartmentRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Department obj)
        {
            _db.Departments.Update(obj);
        }
    }
}
