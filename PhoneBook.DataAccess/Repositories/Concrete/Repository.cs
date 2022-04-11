using PhoneBook.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
namespace PhoneBook.DataAccess.Concrete
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext _context;
        private DbSet<TEntity> _dbSet;
        public Repository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
        public async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public async Task AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return _dbSet.ToList();
        }

        public async Task<TEntity> GetById(string id)
        {
            return _dbSet.Find(id);
        }

        public async Task Remove(string id)
        {
            _dbSet.Remove(await GetById(id));
        }

        public async Task RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }
    }

}
