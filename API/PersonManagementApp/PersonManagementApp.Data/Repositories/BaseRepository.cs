using Microsoft.EntityFrameworkCore;
using PersonManagementApp.Data.Data;
using PersonManagementApp.Data.Interfaces;

namespace PersonManagementApp.Data.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly PersonManageAppDbContext _context;

        public BaseRepository(PersonManageAppDbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public void Delete(int id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity == null)
                return;

            _context.Set<T>().Remove(entity);
        }

        public IQueryable<T> GetQuery(
            System.Linq.Expressions.Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "")
        {
            IQueryable<T> query = _context.Set<T>();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (!string.IsNullOrEmpty(includeProperties))
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty.Trim());
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return query;
        }

        public IEnumerable<T> GetAll()
        {
            var entities = _context.Set<T>().ToList();
            return entities;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return entities;
        }

        public T? GetById(int id)
        {
            var entity = _context.Set<T>().Find(id);
            return entity;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            return entity;
        }

        public IQueryable<T> GetQuery()
        {
            IQueryable<T> query = _context.Set<T>();
            return query;
        }

        public IQueryable<T> GetQuery(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = _context.Set<T>().Where(predicate);
            return query;
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
