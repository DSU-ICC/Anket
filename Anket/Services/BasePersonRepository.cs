using Anket.DBService;
using Anket.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Services
{
    public class BasePersonRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly BasepersonMdfContext _basepersonMdfContext;
        private readonly DbSet<TEntity> _dbSet;
        public BasePersonRepository(BasepersonMdfContext basepersonMdfContext)
        {
            _basepersonMdfContext = basepersonMdfContext;
            _dbSet = _basepersonMdfContext.Set<TEntity>();
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
            _basepersonMdfContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _basepersonMdfContext.Entry(item).State = EntityState.Modified;
            _basepersonMdfContext.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _basepersonMdfContext.SaveChanges();
        }

        public void Save()
        {
            _basepersonMdfContext.SaveChanges();
        }
    }
}
