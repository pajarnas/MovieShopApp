using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using Infrastructure.DataContext;
using ApplicationCore.RepositoryInterfaces;
namespace Infrastructure.Repositories
{
    public class AdminRepository:IAdminRepository
    {
        protected readonly MovieShopDbContext _dbContext;

        public AdminRepository(MovieShopDbContext movieShopDbContext)
        {
            _dbContext = movieShopDbContext;
        }

        public async Task<int> AddMovieGenres(Movie movie, IEnumerable<Genre> genres)
        {
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            foreach (var item in genres)
            {
                movieGenres.Add(new MovieGenre
                {
                    Movie = movie,
                    Genre = item
                });

            }
            await _dbContext.Set<MovieGenre>().AddRangeAsync(movieGenres);
            
            return await _dbContext.SaveChangesAsync();
        }
    }
}
