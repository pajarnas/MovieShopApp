using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<IEnumerable<Review>> GetReviewsByMovie(int movieId);

        Task<decimal> GetAvgReviewRatingByMovie(int movieId);
    }
}
