using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Entities;
//using ApplicationCore.Helpers;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
using AutoMapper;

namespace Infrastructure.Helpers
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
            //CreateMap<Movie, MovieDetailResponseModel>();
            //CreateMap<Cast, CastDetailsResponseModel>()
                //.ForMember(c => c.Movies, opt => opt.MapFrom(src => GetMoviesForCast(src.MovieCasts)));
                
       
                CreateMap<Movie, MovieDetailResponseModel>()
                    .ForMember(md => md.Casts, opt => opt.MapFrom(src => GetCasts(src.MovieCasts)))
                    .ForMember(md => md.Genres, opt => opt.MapFrom(src => GetGenres(src.MovieGenres)));

           
            
            
           // CreateMap<User, UserRegisterResponseModel>();

           CreateMap<IEnumerable<Purchase>, PurchaseResponseModel>()
                .ForMember(p => p.PurchasedMovies, opt => opt.MapFrom(src => GetPurchasedMovies(src)))
                .ForMember(p => p.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            CreateMap<IEnumerable<Purchase>, UserProfileResponseModel>().
                
                ForMember(p => p.PurchasedMovies, opt => opt.MapFrom(src => GetPurchasedMoviesForProfile(src)));
            CreateMap<User, UserProfileResponseModel>();
            //   CreateMap<IEnumerable<Favorite>, FavoriteResponseModel>()
            //  .ForMember(p => p.FavoriteMovies, opt => opt.MapFrom(src => GetFavoriteMovies(src)))
            //    .ForMember(p => p.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            // CreateMap<IEnumerable<Review>, ReviewResponseModel>()
            //   .ForMember(r => r.MovieReviews, opt => opt.MapFrom(src => GetUserReviewedMovies(src)))
            //   .ForMember(r => r.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            //   CreateMap<Review, ReviewMovieResponseModel>()
            //   .ForMember(r => r.Name, opt => opt.MapFrom(src => src.User.FirstName + " " + src.User.LastName));

            CreateMap<Purchase, MovieResponseModel>().ForMember(p => p.Id, opt => opt.MapFrom(src => src.Movie.Id))
                .ForMember(p => p.Title, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(p => p.PosterUrl, opt => opt.MapFrom(src => src.Movie.PosterUrl));

            CreateMap<User, UserLoginResponseModel>();

            // CreateMap<Role, RoleModel>();
            CreateMap<Genre, AssignedGenreModel>();
            /*CreateMap<Genre, AssignedGenreModel>().ForMember(p=>p.Assigned,opt=>opt.MapFrom(src=>false))
                .ForMember(p=>p.Id,opt=>opt.MapFrom(src=>src.Id))
                .ForMember(p=>p.Name,opt=>opt.MapFrom(src=>src.Name));*/

            // CreateMap<CreateMovieRequestModel, Movie>();
            //.ForMember( m => m.MovieGenres, opt => opt.MapFrom( src => GetMovieGenres(src.Genres)));

            // Request Models to Db Entities Mappings
            CreateMap<PurchaseRequestModel, Purchase>();
            //  CreateMap<FavoriteRequestModel, Favorite>();
            //  CreateMap<ReviewRequestModel, Review>();

        }
        
        private static List<MovieDetailsResponseModel.CastResponseModel> GetCasts(IEnumerable<MovieCast> srcMovieCasts)
        {
            var movieCast = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var cast in srcMovieCasts)
                movieCast.Add(new MovieDetailsResponseModel.CastResponseModel
                {
                    Id = cast.CastId,
                    Gender = cast.Cast.Gender,
                    Name = cast.Cast.Name,
                    ProfilePath = cast.Cast.ProfilePath,
                    TmdbUrl = cast.Cast.TmdbUrl,
                    Character = cast.Character
                });

            return movieCast;
        }
        
        private static List<MovieDetailResponseModel.GenreResponseModel> GetGenres(IEnumerable<MovieGenre> srcMovieGenres)
        {
            var movieGenres = new List<MovieDetailResponseModel.GenreResponseModel>();
            foreach (var genre in srcMovieGenres)
                movieGenres.Add(new MovieDetailResponseModel.GenreResponseModel
                {
                    Id = genre.GenreId,
                   
                    Name = genre.Genre.Name,
                    
                });

            return movieGenres;
        }

        //private List<Genre> GetMovieGenres(IEnumerable<MovieGenre> srcGenres)
        //{
        //    var movieGenres = new List<Genre>();
        //    foreach (var genre in srcGenres)
        //    {
        //        movieGenres.Add(new Genre { Id = genre.GenreId, Name = genre.Genre.Name });
        //    }

        //    return movieGenres;
        //}
        /*
        private List<ReviewMovieResponseModel> GetUserReviewedMovies(IEnumerable<Review> reviews)
        {
            var reviewResponse = new ReviewResponseModel { MovieReviews = new List<ReviewMovieResponseModel>() };

            foreach (var review in reviews)
                reviewResponse.MovieReviews.Add(new ReviewMovieResponseModel
                {
                    MovieId = review.MovieId,
                    Rating = review.Rating,
                    UserId = review.UserId,
                    ReviewText = review.ReviewText
                });

            return reviewResponse.MovieReviews;
        }

        private List<FavoriteResponseModel.FavoriteMovieResponseModel> GetFavoriteMovies(
            IEnumerable<Favorite> favorites)
        {
            var favoriteResponse = new FavoriteResponseModel
            {
                FavoriteMovies = new List<FavoriteResponseModel.FavoriteMovieResponseModel>()
            };
            foreach (var favorite in favorites)
                favoriteResponse.FavoriteMovies.Add(new FavoriteResponseModel.FavoriteMovieResponseModel
                {
                    PosterUrl = favorite.Movie.PosterUrl,
                    Id = favorite.MovieId,
                    Title = favorite.Movie.Title
                });

            return favoriteResponse.FavoriteMovies;
        }
        */
        private List<PurchaseResponseModel.PurchasedMovieResponseModel> GetPurchasedMovies(
            IEnumerable<Purchase> purchases)
        {
            var purchaseResponse = new PurchaseResponseModel
            {
                PurchasedMovies =
                    new List<PurchaseResponseModel.PurchasedMovieResponseModel>()
            };
            foreach (var purchase in purchases)
                purchaseResponse.PurchasedMovies.Add(new PurchaseResponseModel.PurchasedMovieResponseModel
                {
                    PosterUrl = purchase.Movie.PosterUrl,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title
                });

            return purchaseResponse.PurchasedMovies;
        }

        private List<UserProfileResponseModel.PurchasedMovieResponseModel> GetPurchasedMoviesForProfile(IEnumerable<Purchase> purchases)
        {
            var userProfileResponseModel = new UserProfileResponseModel
            {
                PurchasedMovies =
                    new List<UserProfileResponseModel.PurchasedMovieResponseModel>()
            };
            foreach (var purchase in purchases)
                userProfileResponseModel.PurchasedMovies.Add(new UserProfileResponseModel.PurchasedMovieResponseModel
                {
                    PosterUrl = purchase.Movie.PosterUrl,
                    PurchaseDateTime = purchase.PurchaseDateTime,
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title

                });

            return userProfileResponseModel.PurchasedMovies;
        }


        /*
                private List<MovieResponseModel> GetMoviesForCast(IEnumerable<MovieCast> srcMovieCasts)
                {
                    var castMovies = new List<MovieResponseModel>();
                    foreach (var movie in srcMovieCasts)
                        castMovies.Add(new MovieResponseModel
                        {
                            Id = movie.MovieId,
                            PosterUrl = movie.Movie.PosterUrl,
                            Title = movie.Movie.Title
                        });

                    return castMovies;
                }*/
        
               
    }
}