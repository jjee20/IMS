﻿using DomainLayer.Models.Inventory;
using DomainLayer.ViewModels.Inventory;
using InfastructureLayer.DataAccess.Data;
using ServiceLayer.Services.IRepositories;
using ServiceLayer.Services.IRepositories.IInventory;

namespace InfastructureLayer.Repositories.Inventory
{
    //public class ProductRepository : BaseRepository, IProductRepository
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDataContext _db;
        public ProductRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }
    }
}
