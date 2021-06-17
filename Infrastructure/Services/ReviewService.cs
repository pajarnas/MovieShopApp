using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
namespace Infrastructure.Services
{
    public class ReviewService:IReviewService
    {
        private readonly IEntityRepository<Review> _repository;
        public ReviewService(IEntityRepository<Review> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Review>> GetReviewsByMovie(int movieId)
        {
            return await _repository.ListWithWhereAsync(r => r.MovieId == movieId);
        }

        public async Task<decimal> GetAvgReviewRatingByMovie(int movieId)
        {
            var reviews = await GetReviewsByMovie(movieId);
            var rating = reviews.Average(m => m.Rating);
            return rating;
        }
        
      
    }
}