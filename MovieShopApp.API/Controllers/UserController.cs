using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.APIModels;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // GET: api/<UserController>/{id}/purchase
        [HttpGet("id")]
        [Route("{id}/purchase")]
        public IEnumerable<string> Get(int id)
        {
            return users.Where(m=>m.id==id).SingleOrDefault().purchase;
        }

        // GET: api/<UserController>/{id}/favourites
        [HttpGet("id")]
        [Route("{id}/favourites")]
        public IEnumerable<string> GetFavs(int id)
        {
            return users.Where(m => m.id == id).SingleOrDefault().favourite;
        }

        // GET: api/<UserController>/{id}/unfavourites
        [HttpGet("id")]
        [Route("{id}/unfavourites")]
        public IEnumerable<string> GetUnfavs(int id)
        {
            return users.Where(m => m.id == id).SingleOrDefault().unfavourite;
        }

      

        // POST api/<UserController>/purchase
        [Route("purchase")]
        [HttpPost]
        public void Post([FromBody] string purchase)
        {
            users[0].purchase.Add(purchase);

        }

        // POST api/<UserController>/favorite
        [Route("favorite")]
        [HttpPost]
        public void PostFavorite([FromBody] string favorite)
        {
            users[0].favourite.Add(favorite);

        }

        // POST api/<UserController>/unfavorite
        [Route("unfavorite")]
        [HttpPost]
        public void PostUnfavorite([FromBody] string unfavorite)
        {
            users[0].unfavourite.Add(unfavorite);

        }

        // GET api/<UserController>/{id}/movie/{movieId}/favorite
        [HttpGet("{id},{movieId}")]
        [Route("{id}/movie/{movieId}/favorite")]
        public List<User> Get(int id, int movieId)
        {
            return users.Where(m=>m.id==id&&m.movieId==movieId).ToList();
        }

        // POST api/<UserController>/review
        [Route("review")]
        [HttpPost]
        public void PostReview([FromBody] string review)
        {
            users[0].review.Add(review);
        }

        // PUT api/<UserController>/review
        [Route("review")]
        [HttpPut]
        public void PutReview(string review,[FromBody] string newReview)
        {
            users[0].review.Remove(review);
            users[0].review.Add(newReview);
        }

        // DELETE api/<UserController>/{userid}/movie/{movieId}
        [HttpDelete("{id},{movieId}")]
        [Route("{userid}/movie/{movieId}")]
        public string Delete(int id)
        {
            return "success";
        }

        private static List<User> users;
        static UserController()
        {
            users = new List<User>()
            {
                new User{id=1,movieId=1,purchase = new List<string> {"purchase1","purchase2"}, favourite= new List<string> {"fav1" },unfavourite=new List<string>{"unfav1"},review=new List<string>{ "a review"} },
                new User{id=2,movieId=2,purchase = new List<string> {"purchase1","purchase2"}, favourite= new List<string> {"fav1" },unfavourite=new List<string>{"unfav1"},review=new List<string>{ "a review"} },
                new User{id=3,movieId=3,purchase = new List<string> {"purchase1","purchase2"}, favourite= new List<string> {"fav1" },unfavourite=new List<string>{"unfav1"},review=new List<string>{ "a review"} },
                new User{id=4,movieId=4,purchase = new List<string> {"purchase1","purchase2"}, favourite= new List<string> {"fav1" },unfavourite=new List<string>{"unfav1"},review=new List<string>{ "a review"} }

            };
        }
    }
}
