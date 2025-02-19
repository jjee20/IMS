﻿using DomainLayer.Models.Inventory;
using DomainLayer.Models.Payroll;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;

namespace InfastructureLayer.Repositories
{
    //public class BonusRepository : BaseRepository, IBonusRepository
    public class BonusRepository : Repository<Bonus>, IBonusRepository
    {
        private ApplicationDataContext _db;
        public BonusRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Bonus obj)
        {
            _db.Bonuses.Update(obj);
        }
    }
}
