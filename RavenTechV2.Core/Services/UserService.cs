using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RavenTechV2.Core.Data;
using RavenTechV2.Core.Models.UserManagement;

namespace RavenTechV2.Core.Services;
public class UserService : Repository<User>, IUserService
{
    private ErpDbContext _db;
    public UserService(ErpDbContext db) : base(db)
    {
        _db = db;
    }
}

public interface IUserService : IRepository<User>
{
}