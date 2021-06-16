using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;
using ApplicationCore.Helpers;

namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieDetailResponseModel>> GetAllMovieModelList();
        // method for getting top 30 highest revenue movies..
        Task<List<MovieDetailResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailResponseModel> GetMovieDetailsById(int id);
        Task<PaginatedList<MovieDetailResponseModel>> GetMoviesPaginatedList(int pageSize = 30, int page = 1, string title="");
 
    }
}
