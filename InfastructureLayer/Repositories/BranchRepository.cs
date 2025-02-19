﻿using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BranchRepository : BaseRepository, IBranchRepository
    public class BranchRepository : Repository<Branch>, IBranchRepository
    {
        private ApplicationDataContext _db;
        public BranchRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Branch obj)
        {
            _db.Branch.Update(obj);
        }
    }
}
