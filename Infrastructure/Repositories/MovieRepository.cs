using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Infrastructure.DataContext;
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

        public async Task<Movie> GetMovieWithGenresAndCasts(int id)
        {
            
            var movie = GetByIdWithIncludesAsync(id: id, filter: m => m.Id == id, 
                include:m =>m
                    .Include( m=>m.MovieCasts)
                    .ThenInclude(mc=>mc.Cast)
                    .Include(m=>m.MovieGenres)
                    .ThenInclude(mg=>mg.Genre) );
            return await movie;
        }
        
        


    }
}
