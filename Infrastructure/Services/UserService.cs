using System;
using System.Net;
using System.Security.Cryptography;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using AutoMapper;
namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMovieService _movieService;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository,IPurchaseRepository purchaseRepository, IMovieService movieService, ICurrentUserService currentUserService, IMapper mapper)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _movieService = movieService;
            _currentUserService = currentUserService;
            _mapper = mapper;
        }

        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // first we need to check the email does not exists in our database

            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);

            if (dbUser != null)
                // email exists in db
                throw new Exception("User already exists, please try to login");

            // generate a unique Salt
            var salt = CreateSalt();

            // hash the password with userRegisterRequestModel.Password + salt from above step
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            // call the user repository to save the user Info

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                DateOfBirth = userRegisterRequestModel.DateOfBirth,
                Salt = salt,
                HashedPassword = hashedPassword
            };

            var createdUser = await _userRepository.AddAsync(user);

            // convert the returned user entity to UserRegisterResponseModel

            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };

            return response;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            {
                // go to database and get the user info -- row by email
                var user = await _userRepository.GetUserByEmail(email);

                if (user == null)
                {
                    // return null
                    return null;
                }

                // get the password from UI and salt from above step from database and call CreateHashedPassword method

                var hashedPassword = CreateHashedPassword(password, user.Salt);

                if (hashedPassword == user.HashedPassword)
                {
                    // user entered correct password

                    var loginResponseModel = new UserLoginResponseModel
                    {
                        Id = user.Id,
                        Email = user.Email,
                        FirstName = user.FirstName,
                        LastName = user.LastName
                    };
                    return loginResponseModel;
                }

                return null;
            }
        }

        private string CreateSalt()
        {
            var randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                Convert.FromBase64String(salt),
                KeyDerivationPrf.HMACSHA512,
                10000,
                256 / 8));
            return hashed;
        }

        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            //check if is it current user
            // set request user id
            // check if is it already purchased
            // get movie price
            // purchaserequestmodel already has purchase datetime, guid

            if (_currentUserService.UserId != purchaseRequest.UserId)
                throw new HttpException(HttpStatusCode.Unauthorized, "You are not Authorized to purchase");
            if (_currentUserService.UserId != null) purchaseRequest.UserId = _currentUserService.UserId.Value;
            // See if Movie is already purchased.
            if (await IsMoviePurchased(purchaseRequest))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieDetailsById(purchaseRequest.MovieId);
            purchaseRequest.TotalPrice = movie.Price;

            var purchase = _mapper.Map<Purchase>(purchaseRequest);
            await _purchaseRepository.AddAsync(purchase);

        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == purchaseRequest.UserId && p.MovieId == purchaseRequest.MovieId);
        }

    
    }
}