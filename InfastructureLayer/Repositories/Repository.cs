﻿using InfastructureLayer.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;
using ServiceLayer.Services.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfastructureLayer.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDataContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDataContext db)
        {
            _db = db;
            dbSet = _db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            dbSet.AddRange(entity);
        }

        public T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.FirstOrDefault();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return query.ToList();
        }
        public void Remove(T entity)
        {
            var keyName = _db.Model.FindEntityType(typeof(T))
                            .FindPrimaryKey()
                            .Properties
                            .Select(x => x.Name)
                            .Single();

            var tracked = dbSet.Local
                .FirstOrDefault(e =>
                    _db.Entry(e).Property(keyName).CurrentValue
                    .Equals(_db.Entry(entity).Property(keyName).CurrentValue));

            if (tracked != null && !ReferenceEquals(tracked, entity))
            {
                _db.Entry(tracked).State = EntityState.Detached;
            }

            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }


        public void RemoveRange(IEnumerable<T> entity)
        {
            dbSet.RemoveRange(entity);
        }
        public void Detach(T entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }

        public async Task AddAsync(T entity)
        {
            await _db.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entity)
        {
            await _db.AddRangeAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }

            query = query.Where(filter);
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false)
        {
            IQueryable<T> query;
            if (tracked)
            {
                query = dbSet;

            }
            else
            {
                query = dbSet.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProp in includeProperties
                    .Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProp);
                }
            }
            return await query.ToListAsync();
        }
        public void Update(T entity)
        {
            var keyName = _db.Model.FindEntityType(typeof(T))
                            .FindPrimaryKey()
                            .Properties
                            .Select(x => x.Name)
                            .Single();

            var trackedEntity = dbSet.Local
                .FirstOrDefault(e =>
                    _db.Entry(e).Property(keyName).CurrentValue
                    .Equals(_db.Entry(entity).Property(keyName).CurrentValue));

            if (trackedEntity != null && !ReferenceEquals(trackedEntity, entity))
            {
                _db.Entry(trackedEntity).State = EntityState.Detached;
            }

            _db.Entry(entity).State = EntityState.Modified;
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity); // reuses safe single update
            }
        }
    }
}