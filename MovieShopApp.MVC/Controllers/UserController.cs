using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
namespace MovieShopApp.MVC.Controllers
{
    
    public class UserController : Controller
    {
        private readonly ICurrentUserService _currentUserService;

        public UserController(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        [Authorize]
        [HttpGet]
        public IActionResult GetUserPurchase()
        {
            var userId = _currentUserService.UserId;
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PurchaseMovie()
        {
            // get userid from CurrentUser and create a row in Purchase Table
            return View();
        }
    }
}
