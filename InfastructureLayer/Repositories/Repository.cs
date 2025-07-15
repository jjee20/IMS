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

        public void UpdateWithChildren<TParent, TChild>(
    TParent parent,
    Expression<Func<TParent, IEnumerable<TChild>>> childSelector,
    Func<TChild, object> keySelector
)
    where TParent : class
    where TChild : class
        {
            // === DETACH PREVIOUSLY TRACKED PARENT (if any) ===
            var keyName = _db.Model.FindEntityType(typeof(TParent))
                .FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .Single();

            var parentKeyValue = typeof(TParent).GetProperty(keyName)?.GetValue(parent);

            var trackedParent = _db.ChangeTracker.Entries<TParent>()
                .FirstOrDefault(e =>
                    e.Property(keyName).CurrentValue != null &&
                    e.Property(keyName).CurrentValue.Equals(parentKeyValue));

            if (trackedParent != null && !ReferenceEquals(trackedParent.Entity, parent))
                trackedParent.State = EntityState.Detached;

            // === Attach the new parent for update ===
            _db.Entry(parent).State = EntityState.Modified;

            // === Update children ===
            var children = childSelector.Compile().Invoke(parent)?.ToList() ?? new List<TChild>();
            var childSet = _db.Set<TChild>();

            // Try to find the parent key property on the child type (assumes FK property is "ParentId")
            var parentIdProperty = typeof(TChild).GetProperties().FirstOrDefault(p => p.Name == keyName);
            var parentId = parentKeyValue;

            // === DETACH PREVIOUSLY TRACKED CHILDREN (if any) ===
            if (parentIdProperty != null)
            {
                var trackedChildren = _db.ChangeTracker.Entries<TChild>()
                    .Where(e =>
                        parentIdProperty.GetValue(e.Entity)?.Equals(parentId) == true)
                    .ToList();

                foreach (var entry in trackedChildren)
                {
                    // Only detach if not the same instance
                    if (!children.Contains(entry.Entity))
                        entry.State = EntityState.Detached;
                }
            }

            // Get existing children (from context/local, could also use DB if necessary)
            var dbChildren = childSet.Local
                .Where(c => parentIdProperty != null && parentIdProperty.GetValue(c)?.Equals(parentId) == true)
                .ToList();

            // Add or update
            foreach (var child in children)
            {
                var key = keySelector(child);
                var existing = dbChildren.FirstOrDefault(c => keySelector(c).Equals(key));
                if (existing == null)
                    _db.Entry(child).State = EntityState.Added;
                else
                    _db.Entry(child).State = EntityState.Modified;
            }

            // Delete removed children
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

        public void UpdateWithChild(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.Update(entity);
        }
    }
}