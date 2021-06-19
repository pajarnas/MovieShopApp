using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using AutoMapper;

namespace Infrastructure.Helpers
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
          
            CreateMap<Movie, MovieDetailResponseModel>()
                    .ForMember(md => md.Casts, opt => opt.MapFrom(src => GetCasts(src)))
                    .ForMember(md => md.Genres, opt => opt.MapFrom(src => GetGenres(src.MovieGenres)));
            CreateMap<Movie, MovieResponseModel>();

           CreateMap<List<Purchase>, UserPurchasesResponseModel>()
                .ForMember(p => p.PurchasedMovies, opt => opt.MapFrom(src => GetPurchasedMovies(src)))
                .ForMember(p => p.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

              CreateMap<User, UserProfileResponseModel>();

      
          

            CreateMap<Purchase, MovieResponseModel>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.Movie.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(p => p.PosterUrl, opt => opt.MapFrom(src => src.Movie.PosterUrl));

            CreateMap<User, UserLoginResponseModel>();

            // CreateMap<Role, RoleModel>();
            CreateMap<Genre, AssignedGenreModel>();
            
            // Request Models to Db Entities Mappings
            CreateMap<PurchaseRequestModel, Purchase>();
        

        }
        
        private static List<MovieDetailResponseModel.CastResponseModel> GetCasts(Movie movie)
        {
            IEnumerable<MovieCast> srcMovieCasts = movie.MovieCasts;
            var movieDetailResponseModel = new MovieDetailResponseModel
            {
                Casts = new List<MovieDetailResponseModel.CastResponseModel>(),
                
            };
            foreach (var cast in srcMovieCasts)
            {
                movieDetailResponseModel.Casts.Add(new MovieDetailResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Gender = cast.Cast.Gender,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    Character = cast.Character
                });
            }
            
            return movieDetailResponseModel.Casts;
        }
        
        private static List<MovieDetailResponseModel.GenreResponseModel> GetGenres(IEnumerable<MovieGenre> srcMovieGenres)
        {
            var movieDetailResponseModel = new MovieDetailResponseModel
            {
                Genres = new List<MovieDetailResponseModel.GenreResponseModel>(),
                
            };
            foreach (var genre in srcMovieGenres)
                movieDetailResponseModel.Genres.Add(new MovieDetailResponseModel.GenreResponseModel
                {
                    Id = genre.GenreId,
                   
                    Name = genre.Genre.Name,
                    
                });

            return movieDetailResponseModel.Genres;
        }
        
        private List<PurchasedMovieResponseModel> GetPurchasedMovies(
            IEnumerable<Purchase> purchases)
        {

            var purchasedMovieResponseModel = new List<PurchasedMovieResponseModel>();
      
            foreach (var purchase in purchases)
                purchasedMovieResponseModel.Add(new PurchasedMovieResponseModel
                {
                    PosterUrl = purchase.Movie.PosterUrl,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title,
                    ReleaseDate = purchase.Movie.ReleaseDate
                });

            return  purchasedMovieResponseModel;
        }

        
       

        

    }
}