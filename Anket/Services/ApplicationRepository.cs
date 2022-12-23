using Anket.DBService;
using Anket.Interface;
using Microsoft.EntityFrameworkCore;
using Sentry;

namespace Anket.Services
{
    public class ApplicationRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _applicationContext;
        private readonly DbSet<TEntity> _dbSet;
        public ApplicationRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = _applicationContext.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
        {
            return _dbSet.AsNoTracking();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate);
        }

        public TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Create(TEntity item)
        {
            _dbSet.Add(item);
            _applicationContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _applicationContext.Entry(item).State = EntityState.Modified;
            _applicationContext.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _applicationContext.SaveChanges();
        }

        public void Save()
        {
            _applicationContext.SaveChanges();
        }
    }
}
