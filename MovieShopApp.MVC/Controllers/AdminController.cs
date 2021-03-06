using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Request;
using AutoMapper;
/*
 * Create AdminController for creating A Movie with Genres, 
 * and it should have submit button that will post to AccounController/CreateMovie method, 
 * Create a model for CreateMovie also
 */

namespace MovieShopApp.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IGenreService _genreService;
        
        public AdminController(IMovieService movieService, IGenreService genreService)
        {
            _movieService = movieService;
            _genreService = genreService;
        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            var details = await _movieService.GetMovieCardsPaginatedList();
            return View(details);
        }
        
        // GET: AdminController/CreateMovie
        public async Task<IActionResult> CreateMovie()
        {
            

            ViewBag.Genres = await _genreService.GetAssignedGenreModelAsync();
            
            return View();
        }

        // POST: AdminController/Create, string[] selectedCourses
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMovie( CreateMovieRequestModel createMovieRequestModel, string[] selectedGenere)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

      
        
    }
}
