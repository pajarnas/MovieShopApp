using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Services;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using Infrastructure.Repositories;
using Infrastructure.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.AspNetCore.Authentication.Cookies;
using MovieShopApp.MVC.Middleware;
using Serilog;
using Infrastructure.Helpers;
namespace MovieShopApp.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MovieShopDbContext>(options =>
                        options.UseSqlServer(Configuration
                            .GetConnectionString("MovieShopDbConnection")));
            services.AddAutoMapper(typeof(Startup), typeof(MovieShopMappingProfile));
            ConfigureDependencyInjection(services);
            services.AddHttpContextAccessor();
           
            

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "MovieShopAuthCookie";
                    options.ExpireTimeSpan = TimeSpan.FromHours(2);
                    options.LoginPath = "/Account/Login";
                });
           
            var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json") .Build();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();
            services.AddSingleton(Log.Logger);



        }

        private void ConfigureDependencyInjection(IServiceCollection services)
        {
           // var connectionString = Configuration.GetValue<string>("AzureBlobStorage");
            // var containerName = Configuration.GetValue<string>("MovieShopBlobContainer");
            
            services.AddRepositories();
            services.AddServices();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                //app.UseMovieShopExceptionMiddleware();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            //app.UseSerilogRequestLogging();
           
            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseLoggerMiddleware();
           
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
