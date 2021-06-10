using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;
using ApplicationCore.Models;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        // GET: api/movies
        [HttpGet]
        public IEnumerable<MovieCreateRequest> Get()
        {
            return movies;
        }

        // GET api/movies/5
        [HttpGet("{id}")]
        public MovieCreateRequest Get(int id)
        {
            return movies.Where(m=>m.Id==id).SingleOrDefault();
        }

        // GET api/movies/toprated
        [HttpGet()]
        [Route("toprated")]
        public MovieCreateRequest GetTopRated()
        {
            var movieId = reviews.OrderBy(r=>r.Rating).Take(1).SingleOrDefault().MovieId;
            
            return movies.Where(m => m.Id == movieId).SingleOrDefault();
        }

        // GET api/movies/toprevenue
        [HttpGet()]
        [Route("toprevenue")]
        public MovieCreateRequest GetTopRevenue()
        {
            var movieId = reviews.OrderBy(r => r.Rating).Take(1).SingleOrDefault().MovieId;

            return movies.Where(m => m.Id == movieId).SingleOrDefault();
        }

        // GET api/movies/genre/{id}
        [HttpGet("{id}")]
        [Route("genre/{id}")]
        public MovieCreateRequest GetTopMovieByGenreId(int id)
        {
          
            return movies[0];
        }

        // GET api/movies/{id}/reviews
        [HttpGet("{id}")]
        [Route("{id}/reviews")]
        public List<ReviewRequestModel> GetMovieReviews(int id)
        {

            return reviews.Where(r => r.MovieId == id).ToList();
        }

        private static List<MovieCreateRequest> movies;
      
        private static List<ReviewRequestModel> reviews;

        static MoviesController() 
        {
            reviews = new List<ReviewRequestModel>()
            {
                new ReviewRequestModel {MovieId=1,Rating=5.6,UserId=1,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=2,Rating=5.6,UserId=2,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=3,Rating=8.6,UserId=3,ReviewText="A Review"},
                new ReviewRequestModel {MovieId=4,Rating=7.6,UserId=4,ReviewText="A Review"},
            };
           
       

           
        }
    }
}
