using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
namespace MovieShopApp.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;

        public MovieController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        // GET: MovieController
        public async Task<ActionResult> Index(int pageSize=30,int pageNumber = 1)
        {
            var details = await _movieService.GetMovieCardsPaginatedList(pageSize,pageNumber);           
            return View(details);
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _movieService.GetMovieDetailsById(id);
            return View(model);
        }

        public async Task<ActionResult> Genre(int genreId)
        {
            var movies = await _movieService.GetMovieCardsPaginatedListByGenre(genreId);
            ViewBag.GenreName = _genreService.GetNameById(genreId);
            return View(movies);
        }

  

     
    }
}
