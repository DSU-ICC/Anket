using System.Linq.Expressions;

namespace DomainService.Common.Interface
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task Create(TEntity item);
        Task<TEntity?> FindById(int id);
        IQueryable<TEntity> Get();
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        public Task Remove(int id);
        Task Remove(TEntity item);
        public Task RemoveRange(IEnumerable<TEntity> items);
        Task Update(TEntity item);
    }
}
