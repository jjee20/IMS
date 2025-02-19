﻿using DomainLayer.Models.Accounts;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class ApplicationUserRepository : BaseRepository, IApplicationUserRepository
    public class ApplicationUserRepository : Repository<ApplicationUser>, IApplicationUserRepository
    {
        private ApplicationDataContext _db;
        public ApplicationUserRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(ApplicationUser obj)
        {
            _db.ApplicationUser.Update(obj);
        }
    }
}
