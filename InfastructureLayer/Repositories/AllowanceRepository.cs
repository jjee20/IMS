﻿using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class AllowanceRepository : BaseRepository, IAllowanceRepository
    public class AllowanceRepository : Repository<Allowance>, IAllowanceRepository
    {
        private ApplicationDataContext _db;
        public AllowanceRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Allowance obj)
        {
            _db.Allowances.Update(obj);
        }
    }
}
