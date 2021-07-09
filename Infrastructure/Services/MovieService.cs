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

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICastRepository _castRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository,IGenreRepository genreRepository, ICastRepository castRepository,IReviewRepository reviewRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _castRepository = castRepository;
            _reviewRepository = reviewRepository;
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

   

        public async Task<MovieDetailResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetMovieWithRelatedData(id);
            var casts = await _castRepository.GetCastsByMovie(id);
            var genres = await _genreRepository.GetGenresByMovie(id);
            var rating = await _reviewRepository.GetAvgReviewRatingByMovie(id);
            MovieDetailResponseModel movieDetailResponseModel = new MovieDetailResponseModel
            {
                Id = movie.Id,
                PosterUrl = movie.PosterUrl,
                ReleaseDate = movie.ReleaseDate,
                Title = movie.Title,
                Overview = movie.Overview,
                Tagline = movie.Tagline,
                Budget = movie.Budget,
                Revenue = movie.Revenue,
                ImdbUrl = movie.ImdbUrl,
                TmdbUrl = movie.TmdbUrl,
                BackdropUrl = movie.BackdropUrl,
                OriginalLanguage = movie.OriginalLanguage,
                RunTime = movie.RunTime,
                Price = movie.Price,
                CreatedBy = movie.CreatedBy,
                UpdatedBy = movie.UpdatedBy,
                CreatedDate = movie.CreatedDate,
                UpdatedDate = movie.UpdatedDate,
                MovieCasts = movie.MovieCasts,
                Casts = casts,
                Genres = genres,
                Rating = rating

            };
            return movieDetailResponseModel;
        }

        public async Task<List<MovieDetailResponseModel>> GetTopRevenueMovies()
        {
            /*    var moviesAsync = await _movieRepository.ListAllAsync();
                var movies = moviesAsync.OrderByDescending(m=>m.Revenue).Take(30).ToList();*/
            var movies = await _movieRepository.GetHighestRevenueMovies();
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
