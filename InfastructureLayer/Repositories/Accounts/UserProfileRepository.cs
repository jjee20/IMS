﻿using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IAccounts;

namespace InfastructureLayer.Repositories.Accounts
{
    //public class UserProfileRepository : BaseRepository, IUserProfileRepository
    public class UserProfileRepository : Repository<UserProfile>, IUserProfileRepository
    {
        private ApplicationDataContext _db;
        public UserProfileRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
