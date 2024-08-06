using PersonManagementApp.Business.Pagination;
using System.Linq.Expressions;

namespace PersonManagementApp.Business.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        //bool Delete(int id);
        Task<bool> DeleteAsync(int id);
        Task<bool> DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<PaginatedResult<T>> GetAsync(
            Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
            string includeProperties = "",
            int pageIndex = 1,
            int pageSize = 10);
    }
}
