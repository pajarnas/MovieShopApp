using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;
using ApplicationCore.Models;
using ApplicationCore.ServiceInterfaces;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MovieShopApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetHighestGrossingMovies()
        {
            var movies = await _movieService.GetTopRevenueMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }
            return NotFound("no movies found");
        }
        
        // GET: MovieController/Details/5
        [HttpGet]
        [Route("Details")]
        public async Task<ActionResult> Details(int id)
        {
            var model = await _movieService.GetMovieDetailsById(id);
            return Ok(model);
        }
    }
}
