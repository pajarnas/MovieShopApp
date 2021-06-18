using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Response;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;
        private readonly ICurrentUserService _currentUserService;
        public UserController(IUserService userService, IConfiguration configuration,ICurrentUserService currentUserService)
        {
            _userService = userService;
            _configuration = configuration;
            _currentUserService = currentUserService;
        }

        [Authorize]
        [HttpGet("{id:int}/purchases")]
        
        public async Task<ActionResult> GetUserPurchasedMovies(int id)
        {
            if (_currentUserService.UserId != id)
            {
                return Unauthorized("please send correct id");
            }
            var purchased = await _userService.GetPurchasedMovieByUser(id);
            return  Ok(purchased);
            
        }
    


        
    }
}
