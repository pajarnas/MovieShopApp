using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models;
using System.Threading.Tasks;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IMovieService
    {
        Task<List<MovieDetailResponseModel>> GetAllMovieModelList();
        // method for getting top 30 highest revenue movies..
        Task<List<MovieDetailResponseModel>> GetTopRevenueMovies();
        Task<MovieDetailResponseModel> GetMovieDetailsById(int id);
    }
}
