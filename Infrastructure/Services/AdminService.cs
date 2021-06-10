using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.Entities;
namespace Infrastructure.Services
{
    public class AdminService : IAdminService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IAdminRepository _adminRepository;
        private readonly IGenreRepository _genreRepository;
        public AdminService(IMovieRepository movieRepository, IAdminRepository adminRepository, IGenreRepository genreRepository)
        {
            _movieRepository = movieRepository;
            _adminRepository = adminRepository;
            _genreRepository = genreRepository;
        }
        public async Task<Movie> AddMovieWithGenres(CreateMovieRequestModel model)
        {
            var genreIds = model.Genres.Select(m => Convert.ToInt32(m)).ToList();
            Movie movie = new Movie 
            {
                PosterUrl = model.PosterUrl,
                ReleaseDate = model.ReleaseDate,
                Title = model.Title,
                Overview = model.Overview,
                Tagline = model.Tagline,
                Budget = model.Budget,
                Revenue = model.Revenue,
                ImdbUrl = model.ImdbUrl,
                TmdbUrl = model.TmdbUrl,
                BackdropUrl = model.BackdropUrl,
                OriginalLanguage = model.OriginalLanguage,
                RunTime = model.RunTime,
                Price = model.Price,
                CreatedBy = model.CreatedBy,
                UpdatedBy = model.UpdatedBy,
                CreatedDate = model.CreatedDate,
                UpdatedDate = model.UpdatedDate
                
            };
            
            List<Genre> genres = new List<Genre>(); 
            foreach (var item in genreIds)
            {
                genres.Add(await _genreRepository.GetByIdAsync(item));
            }
            List<MovieGenre> movieGenres = new List<MovieGenre>();
            foreach (var item in genres)
            {
                movieGenres.Add(new MovieGenre
                {
                    Movie = movie,
                    Genre = item
                });

            }

            movie.MovieGenres = movieGenres;
            return await _movieRepository.AddAsync(movie);


        }
    }
}
