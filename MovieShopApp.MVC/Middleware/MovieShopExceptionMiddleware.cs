using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Exceptions;
using System.Net;

namespace MovieShopApp.MVC.Middleware
{
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private ILogger<MovieShopExceptionMiddleware> _logger;

        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {              
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                // do your exception handling
                _logger.LogInformation("Some Exception happened, caught in this middleware: ");

                await HandleException(httpContext, ex);
            }


        }

        private async Task HandleException(HttpContext httpContext, Exception ex)
        {
            // get the exception, log with seri log and send email to dev team
            _logger.LogError("Starting Exception Logging: ");
            switch (ex)
            {
                case ConflictException conflictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }

            var errorResponse = new
            {
                ExceptionMessage = ex.Message,
                InnerExceptionMessage = ex.InnerException,
                ExceptionStackTrace = ex.StackTrace
            };

            _logger.LogError("Exception Message: {0}", errorResponse.ExceptionMessage);
            _logger.LogError("Exception happened on {0}", DateTime.Now);
            _logger.LogError("StackTrace Of Exception {0}", errorResponse.ExceptionStackTrace);

            // redirect to a error page
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;

        }

    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }
}