using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
     
        public MovieRepository(MovieShopDbContext dbcontext) : base(dbcontext)
        {
            
        }

        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {

            return await _dbContext.Set<Movie>().OrderByDescending(m=>m.Revenue).Take(30).ToListAsync();
        }

        public Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            throw new NotImplementedException();
        }

        public async Task<Movie> GetMovieWithRelatedData(int id)
        {
            var movie = _dbContext.Movie
                             .Include(m => m.Favorites)
                             .Include(m => m.MovieCasts)
                             .Where(m=>m.Id==id)
                             .FirstOrDefaultAsync();
            return await movie;
        }
    }
}
