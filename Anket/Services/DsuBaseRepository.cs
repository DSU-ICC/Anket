using Anket.DBService;
using Anket.Interface;
using Microsoft.EntityFrameworkCore;

namespace Anket.Services
{
    public class DsuBaseRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly DsuContext _dsuContext;
        private readonly DbSet<TEntity> _dbSet;
        public DsuBaseRepository(DsuContext dsuContext)
        {
            _dsuContext = dsuContext;
            _dbSet = _dsuContext.Set<TEntity>();
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
            _dsuContext.SaveChanges();
        }

        public void Update(TEntity item)
        {
            _dsuContext.Entry(item).State = EntityState.Modified;
            _dsuContext.SaveChanges();
        }

        public void Remove(TEntity item)
        {
            _dbSet.Remove(item);
            _dsuContext.SaveChanges();
        }

        public void Save()
        {
            _dsuContext.SaveChanges();
        }
    }
}
