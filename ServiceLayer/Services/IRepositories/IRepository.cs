using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServiceLayer.Services.IRepositories
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(IEnumerable<T> entity);
        T Get(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);
        void Detach(T entity);

        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entity);
        Task<T> GetAsync(Expression<Func<T, bool>> filter, string? includeProperties = null, bool tracked = false);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, string? includeProperties = null, bool tracked = false);
        void Update(T entity);

        void UpdateWithChild<TChild>(
        T entity,
        Expression<Func<T, TChild>> childSelector,
        Func<TChild, object> keySelector)
        where TChild : class;

        void UpdateWithChildren<TParent, TChild>(
       TParent parent,
       Expression<Func<TParent, IEnumerable<TChild>>> childSelector,
       Func<TChild, object> keySelector
        )
       where TParent : class
       where TChild : class;

        void DetachLocal(Func<T, bool> predicate);
    }
}