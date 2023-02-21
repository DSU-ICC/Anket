using System.Linq.Expressions;

namespace Anket.Common.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity> FindById(int id);
        IQueryable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        public Task Remove(int id);
        Task Remove(TEntity item);
        public Task RemoveRange(IEnumerable<TEntity> items);
        Task Update(TEntity item);
        public IQueryable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties);
        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate, params Expression<Func<TEntity, object>>[] includeProperties);
        public TEntity GetWithIncludeById(Func<TEntity, bool> id, params Expression<Func<TEntity, object>>[] includeProperties);
    }
}
