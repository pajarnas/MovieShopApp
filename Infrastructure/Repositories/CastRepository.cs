using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Linq;
using ApplicationCore.RepositoryInterfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Infrastructure.DataContext;
namespace Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDbContext dbcontext) : base(dbcontext)
        {

        }

        public async Task<IEnumerable<Cast>> GetCastsByMovie(int movieId)
        {
            var casts = await _dbContext.Set<MovieCast>().Where(m => m.MovieId == movieId).Include(c => c.Cast).Include(c => c.Movie).Select(c => new Cast { Id=c.Cast.Id,Character=c.Character,Name=c.Cast.Name,ProfilePath=c.Cast.ProfilePath }).ToListAsync();
           
            
            return casts;
        }
    }
}
