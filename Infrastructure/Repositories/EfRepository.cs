using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ApplicationCore.RepositoryInterfaces;
using System.Threading.Tasks;
using ApplicationCore.Helpers;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Repositories
{
    public class EfRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly MovieShopDbContext _dbContext;

        public EfRepository(MovieShopDbContext dbContext)
        {
            dbContext.Database.SetCommandTimeout(300); 
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }
        
        public virtual async Task<T> GetByIdWithIncludesAsync(int id,Expression<Func<T, bool>> filter, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (include != null)
                query = include(query);
            
            if (filter != null)
                query = query.Where(filter);

            return await query.SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> ListWithWhereAsync(Expression<Func<T, bool>> filter)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<T>> ListWithIncludesAsync(Expression<Func<T, bool>> filter, params Expression<Func<T, object>>[] includes)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (includes != null)
                foreach (Expression<Func<T, object>> navigationProperty in includes)
                    query = query.Include(navigationProperty);
            
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
        }
       
        public virtual async Task<PaginatedList<T>> GetPagedDataAsync(int pageIndex, int pageSize,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null,
            Expression<Func<T, bool>> filter = null, params Expression<Func<T, object>>[] includes)
        {
            var pagedList =
                await PaginatedList<T>.GetPaged(_dbContext.Set<T>(), pageIndex, pageSize, orderedQuery, filter, includes);
            return pagedList;
        }

      

        public virtual async Task<T> AddAsync(T entity)
        {
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();
            return  entity;
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return entity;
        }
        
        public virtual async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<int> GetCountAsync(Expression<Func<T, bool>> filter)
        {
            if (filter != null)
                return await _dbContext.Set<T>().Where(filter).CountAsync();
            return await _dbContext.Set<T>().CountAsync();
        }

        public async Task<bool> GetExistsAsync(Expression<Func<T, bool>> filter)
        {
            if (filter == null) return false;
            return await _dbContext.Set<T>().Where(filter).AnyAsync();
        }
    }
}
