using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace ApplicationCore.RepositoryInterfaces
{
    public interface IMovieRepository :IEntityRepository<Movie> ,IPaginatedRepository<Movie>,IRelationRepository<Movie>
    {
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<IEnumerable<Movie>> GetHighestRevenueMovies();
        Task<Movie> GetMovieWithGenresAndCasts(int id);
       
    }
}


