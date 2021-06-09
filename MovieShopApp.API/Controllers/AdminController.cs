using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        // GET: api/Admin/movie
        [Route("movie")]
        [HttpGet]
        public IEnumerable<string> GetMovie()
        {
            return new string[] { "MovieAdmin", "MovieAdmin2" };
        }

        // PUT: api/Admin/movie
        [Route("movie")]
        [HttpPut]
        public IEnumerable<string> PutMovie()
        {
            return new string[] { "PutMovieAdmin", "PutMovieAdmin2" };
        }

        // GET: api/Admin/purchases
        [Route("purchases")]
        [HttpGet]
        public IEnumerable<string> GetPurchase()
        {
            return new string[] { "purchasesAdmin", "purchasesAdmin2" };
        }
        
    }
}
