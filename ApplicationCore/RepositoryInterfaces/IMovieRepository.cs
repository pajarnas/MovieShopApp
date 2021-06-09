using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository :IAsyncRepository<Movie> 
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();

        Task<Movie> GetMovieWithRelatedData(int id);
       
    }
}


