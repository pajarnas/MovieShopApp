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
    public class RelationRepository<T> : IRelationRepository<T> where T:class
    {
        protected readonly MovieShopDbContext _dbContext;

        public RelationRepository(MovieShopDbContext dbContext)
        {
            dbContext.Database.SetCommandTimeout(300); 
            _dbContext = dbContext;
        }
        
        public async Task<IEnumerable<T>> ListWithIncludesAsync( Func<IQueryable<T>, IIncludableQueryable<T, object>> include,Expression<Func<T, bool>> filter)
        {
            var query = _dbContext.Set<T>().AsQueryable();

            if (include != null)
                query = include(query);
            
            if (filter != null)
                query = query.Where(filter);

            return await query.ToListAsync();
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
    }
}