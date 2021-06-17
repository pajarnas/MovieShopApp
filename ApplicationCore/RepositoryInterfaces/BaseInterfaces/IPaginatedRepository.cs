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
    public interface IPaginatedRepository<T> where T:class
    {
         Task<PaginatedList<T>> GetPagedDataAsync(int pageIndex, int pageSize, IQueryable<T> source, Func<IQueryable<T>, IOrderedQueryable<T>> orderedQuery = null, Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> include = null);
    }
}