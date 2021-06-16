using System;
using System.Collections.Generic;
using System.Text;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.Entities;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using ApplicationCore.Helpers;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICastRepository _castRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository,IGenreRepository genreRepository, ICastRepository castRepository,IReviewRepository reviewRepository,IMapper mapper)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _castRepository = castRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }
        public async Task<List<MovieDetailResponseModel>> GetAllMovieModelList()
        {
            var moviesAsync = await _movieRepository.ListAllAsync();
            var movies = moviesAsync.Take(30).ToList();
            List<MovieDetailResponseModel> models = new List<MovieDetailResponseModel>();
            foreach (var movie in movies)
            {
                models.Add(new MovieDetailResponseModel
                {
                    Id = movie.Id,PosterUrl=movie.PosterUrl,ReleaseDate=movie.ReleaseDate,Title=movie.Title
                }); 
            }
          
            return models;
        }

        public async Task<PaginatedList<MovieDetailResponseModel>> GetMoviesPaginatedList(int pageSize = 30, int page = 1,
            string title = "")
        {
            //get PaginatedList<Movie>
            var pagedData = await _movieRepository.GetPagedData(page, pageSize);
            //mapping it to PaginatedList<MovieDetailResponseModel>
            var mappedPagedData = _mapper.Map<PaginatedList<MovieDetailResponseModel>>(pagedData);
            var pagedModels = new PaginatedList<MovieDetailResponseModel>(mappedPagedData,count:pagedData.TotalCount,page=page,pageSize=pageSize);
            return pagedModels;
        }

        public async Task<MovieDetailResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetMovieWithRelatedData(id);
            var movieDetailResponseModel = _mapper.Map<MovieDetailResponseModel>(movie);
            return movieDetailResponseModel;
        }

        public async Task<List<MovieDetailResponseModel>> GetTopRevenueMovies()
        {
            var moviesAsync = await _movieRepository.ListAllAsync();
            var movies = moviesAsync.OrderByDescending(m=>m.Revenue).Take(30).ToList();
            List<MovieDetailResponseModel> models = new List<MovieDetailResponseModel>();
            foreach (var movie in movies)
            {
                models.Add(new MovieDetailResponseModel
                {
                    Id = movie.Id,
                    PosterUrl = movie.PosterUrl,
                    ReleaseDate = movie.ReleaseDate,
                    Title = movie.Title
                });
            }

            return models;
        }

   
    }
}
