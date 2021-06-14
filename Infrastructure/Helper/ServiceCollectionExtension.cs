﻿using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Helpers
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<ICastRepository, CastRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAsyncRepository<Favorite>, EfRepository<Favorite>>();
            services.AddScoped<IAsyncRepository<Purchase>, EfRepository<Purchase>>();
            services.AddScoped<IAsyncRepository<Genre>, EfRepository<Genre>>();
            services.AddScoped<IAsyncRepository<Review>, EfRepository<Review>>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IGenreService, GenreService>();
            
            services.AddScoped<ICastService, CastService>();
         
        }
    }
}