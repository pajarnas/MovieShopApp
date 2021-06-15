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
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDbContext dbcontext) : base(dbcontext)
        {

        }

        public async Task<IEnumerable<Review>> GetReviewsByMovie(int movieId)
        {
            
            var reviews = await _dbContext.Set<Review>().Where(m => m.MovieId == movieId).ToListAsync();


            return reviews;
            
        }

        public async Task<decimal> GetAvgReviewRatingByMovie(int movieId)
        {
            var reviews = await GetReviewsByMovie(movieId);
            var rating = reviews.Average(m => m.Rating);
            return rating;
        }
    }
}
