using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Linq;
using ApplicationCore.RepositoryInterfaces;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Models.Response;
using Infrastructure.DataContext;
namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>,IGenreRepository
    {
        public GenreRepository(MovieShopDbContext dbcontext) : base(dbcontext)
        {

        }

        public async Task<IEnumerable<Genre>> GetGenresByMovie(int movieId)
        {
            
            var genres = await _dbContext.Set<MovieGenre>().Where(m => m.MovieId == movieId).Include(c => c.Genre).Select(c=>c.Genre).ToListAsync();


            return genres;
            
        }

       
    }
}
