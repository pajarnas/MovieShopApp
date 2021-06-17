using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ApplicationCore.Helpers;
using Microsoft.EntityFrameworkCore.Query;

namespace ApplicationCore.RepositoryInterfaces
{
    //common CRUD operations
    public interface IAsyncRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdWithIncludesAsync(int id, Expression<Func<T, bool>> filter,Func<IQueryable<T>,IIncludableQueryable<T,object>> include);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListWithWhereAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> ListWithIncludesAsync(Expression<Func<T, bool>> filter,
            params Expression<Func<T, object>>[] includes);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<PaginatedList<T>> GetPagedDataAsync(int pageIndex, int pageSize, Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null, Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes);
        

    }
}
