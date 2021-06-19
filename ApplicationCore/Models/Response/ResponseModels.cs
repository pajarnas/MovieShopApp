using System;
using System.Collections.Generic;

namespace ApplicationCore.Models.Response
{
    public class UserRegisterResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

   

     

    public class UserLoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
   
    }


    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UserPurchasesResponseModel
    {
        public int UserId { get; set; }
        public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }

        
    }
    
    public class UserProfileResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public DateTime? DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? LastLoginDateTime { get; set; }
        public List<PurchasedMovieResponseModel> PurchasedMovies { get; set; }

       
    }
    public   class PurchasedMovieResponseModel : MovieResponseModel
    {
        public DateTime PurchaseDateTime { get; set; }
    }

    public class MovieResponseModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string PosterUrl { get; set; }
        public DateTime? ReleaseDate { get; set; }
    }
    

    public class GenreModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AssignedGenreModel
    {
        public AssignedGenreModel()
        {
            Assigned = false;
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public bool Assigned { get; set; }
    }


    public class MovieChartResponseModel
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int PurchaseCount { get; set; }
    }

    public class FavoriteResponseModel
    {
        public int UserId { get; set; }
        public List<FavoriteMovieResponseModel> FavoriteMovies { get; set; }

        public class FavoriteMovieResponseModel : MovieResponseModel
        {
        }
    }

    public class CastDetailsResponseModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TmdbUrl { get; set; }
        public string ProfilePath { get; set; }
        public IEnumerable<MovieResponseModel> Movies { get; set; }
    }

    public class ReviewResponseModel
    {
        public int UserId { get; set; }
        public List<ReviewMovieResponseModel> MovieReviews { get; set; }
    }

    public class ReviewMovieResponseModel
    {
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public string ReviewText { get; set; }
        public decimal Rating { get; set; }
        public string Name { get; set; }
    }
}