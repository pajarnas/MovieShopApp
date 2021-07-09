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

using Microsoft.EntityFrameworkCore.Query;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IEntityRepository<Genre> _genreRepository;
        private readonly ICastRepository _castRepository;
        private readonly IEntityRepository<Review> _reviewRepository;
        private readonly IRelationRepository<MovieGenre> _movieGenreRepository;
        private readonly IReviewService _reviewService;
        private readonly IMapper _mapper;
        public MovieService(IMovieRepository movieRepository,IEntityRepository<Review> reviewRepository, ICastRepository castRepository,IEntityRepository<Genre> genreRepository,IMapper mapper,IReviewService reviewService,IRelationRepository<MovieGenre> movieGenreRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _castRepository = castRepository;
            _reviewRepository = reviewRepository;
            _reviewService = reviewService;
            _movieGenreRepository = movieGenreRepository;
            _mapper = mapper;
        }
       
        public async Task<PaginatedList<MovieResponseModel>> GetMovieCardsPaginatedList(int pageSize = 30, int page = 1,
            IQueryable<Movie> source = null, string title = "")
        {
            //get PaginatedList<Movie>
            var pagedData = await _movieRepository.GetPagedDataAsync(pageIndex:page, pageSize:pageSize,source);
            //mapping it to PaginatedList<MovieResponseModel>
            var mappedPagedData = _mapper.Map<PaginatedList<MovieResponseModel>>(pagedData);
            var pagedModels = new PaginatedList<MovieResponseModel>(mappedPagedData,count:pagedData.TotalCount,page=page,pageSize=pageSize);
            return pagedModels;
        }

        public async Task<MovieDetailResponseModel> GetMovieDetailsById(int id)
        {
            var movie = await _movieRepository.GetMovieWithGenresAndCasts(id);
            movie.Rating = await _reviewService.GetAvgReviewRatingByMovie(id);
            var movieDetailResponseModel = _mapper.Map<Movie,MovieDetailResponseModel>(movie);
            return movieDetailResponseModel;
        }

        public async Task<List<MovieResponseModel>> GetTopRevenueMovies()
        {
            var ordered = await _movieRepository.ListWithOrderedAsync(m=>m.OrderByDescending(m=>m.Revenue));
            var movies = ordered.Take(30).ToList();
            var models = _mapper.Map<List<MovieResponseModel>>(movies);
            return models;
        }
        
        
    

        public async Task<PaginatedList<MovieResponseModel>> GetMovieCardsPaginatedListByGenre(int genreId, int pageSize = 30,
            int page = 1, string title = "")
        {
            
            var movieGenres = await _movieGenreRepository.ListWithIncludesAsync(mg=>mg.Include(m=>m.Movie).Include(m=>m.Genre),mg=>mg.GenreId==genreId);
            
            var movies = movieGenres.AsQueryable().Select(c => c.Movie);

            

            var pagedModels = GetMovieCardsPaginatedList( pageSize:pageSize , page:page,source:movies);

            return await pagedModels;

        }
    }
}
