using Microsoft.EntityFrameworkCore;
using PersonManagementApp.Business.Interfaces;
using PersonManagementApp.Business.Pagination;
using PersonManagementApp.Data.Interfaces;
using System.Linq.Expressions;

namespace PersonManagementApp.Business.Services
{
    public class BaseService<T> : IBaseService<T> where T : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly DbSet<T> _dbSet;

        public BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbSet = _unitOfWork.Context.Set<T>();
        }

        public virtual async Task<int> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            return await _unitOfWork.SaveChangesAsync();
        }

        public virtual async Task<bool> UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        //public bool Delete(int id)
        //{
        //    var entity = _dbSet.Find(id);
        //    if (entity == null)
        //        return false;

        //    _dbSet.Remove(entity);
        //    _unitOfWork.SaveChanges();
        //    return true;
        //}

        public virtual async Task<bool> DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
            return await _unitOfWork.SaveChangesAsync() > 0;
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<PaginatedResult<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "",
            int pageIndex = 1,
            int pageSize = 10)
        {
            IQueryable<T> query = _unitOfWork.BaseRepository<T>().GetQuery(filter, orderBy, includeProperties);

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedResult<T>(items, totalCount, pageIndex, pageSize);
        }
    }
}
