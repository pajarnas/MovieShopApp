using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
namespace MovieShopApp.MVC.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: MovieController
        public async Task<ActionResult> Index(int pageSize=30,int pageNumber = 1)
        {
            var details = await _movieService.GetMoviesPaginatedList(pageSize,pageNumber);           
            return View(details);
        }

        // GET: MovieController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _movieService.GetMovieDetailsById(id);
            return View(model);
        }

  

     
    }
}
