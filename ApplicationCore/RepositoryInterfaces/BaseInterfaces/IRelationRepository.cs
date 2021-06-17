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
    public interface IRelationRepository<T> where T:class
    {
         Task<T> GetByIdWithIncludesAsync(int id, Expression<Func<T, bool>> filter,Func<IQueryable<T>,IIncludableQueryable<T,object>> include);
         Task<IEnumerable<T>> ListWithIncludesAsync( Func<IQueryable<T>,IIncludableQueryable<T,object>> include,Expression<Func<T, bool>> filter);
    }
}