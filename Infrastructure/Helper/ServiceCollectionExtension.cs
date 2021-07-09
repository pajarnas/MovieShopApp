using ApplicationCore.Entities;
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
            services.AddScoped<IEntityRepository<Favorite>, EfRepository<Favorite>>();
            services.AddScoped<IEntityRepository<Purchase>, EfRepository<Purchase>>();
            services.AddScoped<IEntityRepository<Genre>, EfRepository<Genre>>();
            services.AddScoped<IEntityRepository<Review>, EfRepository<Review>>();
            services.AddScoped<IRelationRepository<MovieGenre>, RelationRepository < MovieGenre >> ();
            services.AddScoped<IRelationRepository<Purchase>, RelationRepository<Purchase>>();
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICastService, CastService>();
            services.AddScoped<IPurchaseService,PurchaseService>();
            services.AddScoped<IReviewService, ReviewService>();


        }
    }
}