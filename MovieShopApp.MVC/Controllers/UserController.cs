using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using ApplicationCore.Models.Request;
namespace MovieShopApp.MVC.Controllers
{
    
    public class UserController : Controller
    {
         
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;
        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> PurchaseMovie(int Id)
        {
            var movie = await _movieService.GetMovieDetailsById(Id);
            ViewBag.Movie = movie;
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Success()
        {
            return View("Success");
        }
        
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie(PurchaseRequestModel purchaseRequestModel)
        {
            // get userid from CurrentUser and create a row in Purchase Table
            await _userService.PurchaseMovie(purchaseRequestModel);

            return RedirectToAction("Success");
        }
       
            


    }
}
