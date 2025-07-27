using InfastructureLayer.DataAccess.Data;
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

        public void Add(T entity) => dbSet.Add(entity);
        public void AddRange(IEnumerable<T> entity) => dbSet.AddRange(entity);

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
        public void RemoveRange(IEnumerable<T> entity) => dbSet.RemoveRange(entity);
        public void Detach(T entity) => _db.Entry(entity).State = EntityState.Detached;

        public async Task AddAsync(T entity) => await _db.AddAsync(entity);

        public async Task AddRangeAsync(IEnumerable<T> entity) => await _db.AddRangeAsync(entity);

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


        public void UpdateWithChildren<TParent, TChild>(
    TParent parent,
    Expression<Func<TParent, IEnumerable<TChild>>> childSelector,
    Func<TChild, object> keySelector
)
    where TParent : class
    where TChild : class
        {
            // === DETACH PREVIOUSLY TRACKED PARENT (if any) ===
            var parentKeyName = _db.Model.FindEntityType(typeof(TParent))
                .FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .Single();

            var parentKeyValue = typeof(TParent).GetProperty(parentKeyName)?.GetValue(parent);

            var trackedParent = _db.ChangeTracker.Entries<TParent>()
                .FirstOrDefault(e =>
                    e.Property(parentKeyName).CurrentValue != null &&
                    e.Property(parentKeyName).CurrentValue.Equals(parentKeyValue));

            if (trackedParent != null && !ReferenceEquals(trackedParent.Entity, parent))
                trackedParent.State = EntityState.Detached;

            _db.Entry(parent).State = EntityState.Modified;

            // === Prepare to sync children ===
            var children = childSelector.Compile().Invoke(parent)?.ToList() ?? new List<TChild>();

            var childEntityType = _db.Model.FindEntityType(typeof(TChild));
            var childKeyName = childEntityType.FindPrimaryKey().Properties.Select(p => p.Name).Single();
            var parentNavProp = childEntityType.GetProperties().FirstOrDefault(p => p.Name == parentKeyName);

            if (parentNavProp == null)
                throw new InvalidOperationException("Could not find foreign key property on child entity.");

            // Now use a compiled lambda or manually filter after materialization
            var dbChildren = _db.Set<TChild>()
                .AsNoTracking()
                .ToList()
                .Where(c => parentNavProp.PropertyInfo.GetValue(c)?.Equals(parentKeyValue) == true)
                .ToList();

            var trackedChildren = _db.ChangeTracker.Entries<TChild>()
                .Select(e => e.Entity)
                .Where(c => parentNavProp != null &&
                            parentNavProp.PropertyInfo.GetValue(c)?.Equals(parentKeyValue) == true)
                .ToList();

            dbChildren.AddRange(trackedChildren.Where(c => !dbChildren.Any(x => keySelector(x).Equals(keySelector(c)))));

            // === Sync logic ===
            foreach (var child in children)
            {
                var key = keySelector(child);
                var match = dbChildren.FirstOrDefault(c => keySelector(c).Equals(key));

                // Get actual PK value
                var keyProp = typeof(TChild).GetProperty(childKeyName);
                var keyVal = keyProp != null ? Convert.ToInt32(keyProp.GetValue(child)) : 0;

                if (match == null || keyVal == 0)
                {
                    // New or unmatched — ensure PK = 0 for new records
                    if (keyProp != null && keyVal == 0)
                        keyProp.SetValue(child, 0);

                    _db.Entry(child).State = EntityState.Added;
                }
                else
                {
                    _db.Entry(child).State = EntityState.Modified;
                }
            }

            // === Delete children missing from new list ===
            foreach (var dbChild in dbChildren)
            {
                if (!children.Any(c => keySelector(c).Equals(keySelector(dbChild))))
                {
                    _db.Entry(dbChild).State = EntityState.Deleted;
                }
            }
        }



        public void UpdateRange(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Update(entity); // reuses safe single update
            }
        }

        public void UpdateWithChild<TChild>(
     T entity,
     Expression<Func<T, TChild>> childSelector,
     Func<TChild, object> keySelector)
     where TChild : class
        {
            DetachLocal(e => GetPrimaryKeyValue(e)?.Equals(GetPrimaryKeyValue(entity)) ?? false);

            var child = childSelector.Compile().Invoke(entity);
            if (child != null)
            {
                var key = keySelector(child);
                if (key is int intKey && intKey == 0)
                    _db.Entry(child).State = EntityState.Added;
                else
                    _db.Entry(child).State = EntityState.Modified;
            }

            _db.Entry(entity).State = EntityState.Modified;
        }

        public void DetachLocal(Func<T, bool> predicate)
        {
            var local = _db.Set<T>().Local.FirstOrDefault(predicate);
            if (local != null)
            {
                _db.Entry(local).State = EntityState.Detached;
            }
        }

        private object? GetPrimaryKeyValue(T entity)
        {
            var key = _db.Model.FindEntityType(typeof(T))?.FindPrimaryKey()?.Properties.FirstOrDefault();
            return key == null ? null : typeof(T).GetProperty(key.Name)?.GetValue(entity, null);
        }
    }
}