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
    public interface IEntityRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> ListAllAsync();
        Task<IEnumerable<T>> ListWithWhereAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> ListWithOrderedAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null);
        Task<int> GetCountAsync(Expression<Func<T, bool>> filter);
        Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter);
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        
        

    }
}
