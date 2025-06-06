﻿using DomainLayer.Models.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ProductTypeRepository : BaseRepository, IProductTypeRepository
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository
    {
        private ApplicationDataContext _db;
        public ProductTypeRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
