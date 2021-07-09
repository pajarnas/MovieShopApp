using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetReviewsByMovie(int movieId);
                Task<decimal> GetAvgReviewRatingByMovie(int movieId);
    }
}