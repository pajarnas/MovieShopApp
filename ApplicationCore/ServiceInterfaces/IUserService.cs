using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.Models.Request;
namespace ApplicationCore.ServiceInterfaces
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel);
        Task<UserLoginResponseModel> Login(string email, string password);

        Task PurchaseMovie(PurchaseRequestModel purchase);
        Task<UserProfileResponseModel> GetUserProfile();


        // delete
        // EditUser
        // Change Password
        // Purchase Movie
        // Favorite Movie
        // Add Review
        // Get All Purchased Movies
        // Get All Favorited Movies
        // Edit Review
        // Remove Favorite
        // Get User Details
        // 

    }
}
