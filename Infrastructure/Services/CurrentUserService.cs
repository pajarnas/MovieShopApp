using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Http;
using ApplicationCore.RepositoryInterfaces;
namespace Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IPurchaseService _purchaseRService;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IPurchaseService purchaseService)
        {
            _httpContextAccessor = httpContextAccessor;
            _purchaseRService = purchaseService;
        }

        // access HttpContext 
        public int? UserId =>
            Convert.ToInt32(_httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public bool? IsAuthenticated => _httpContextAccessor.HttpContext?.User.Identity != null &&
                                       _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;

        public string Email => _httpContextAccessor.HttpContext?.User.Claims
            .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        public string FullName => _httpContextAccessor.HttpContext?.User.Claims
                                      .FirstOrDefault(c => c.Type == ClaimTypes.GivenName)?.Value + " " +
                                  _httpContextAccessor.HttpContext?.User.Claims
                                      .FirstOrDefault(c => c.Type == ClaimTypes.Surname)?.Value;
        public int MyMoviesCount => GetUserPurchasedMovieCount().Result;
        public bool? IsAdmin { get; }
        public IEnumerable<string> Roles { get; }


        public async Task<int> GetUserPurchasedMovieCount()
        {
            var count = _purchaseRService.GetPurchasedMoviesCountByUser(UserId.Value);
            return await count;
        }



    }
}
