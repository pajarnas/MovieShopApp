using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;
using ApplicationCore.Helpers;
using ApplicationCore.Entities;
using System.Linq;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
  
        // method for getting top 30 highest revenue movies..
        Task<IEnumerable<Movie>> GetTopRevenueMovies();
        Task<MovieDetailResponseModel> GetMovieDetailsById(int id);
        Task<PaginatedList<MovieResponseModel>> GetMovieCardsPaginatedList(int pageSize = 30, int page = 1, IQueryable<Movie> source=null,string title="");
        Task<PaginatedList<MovieResponseModel>> GetMovieCardsPaginatedListByGenre(int genreId,int pageSize = 30, int page = 1, string title="");

    
    }
}
