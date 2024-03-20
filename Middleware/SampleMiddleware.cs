using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddlewareApp.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SampleMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public SampleMiddleware(RequestDelegate next, ILoggerFactory logger)
        {
            _next = next;
            _logger = logger.CreateLogger("My Middle ware logs");
        }

        public async Task Invoke(HttpContext httpContext)
        {
            _logger.LogInformation("Welcome to My Logger in custom middleware");
            await _next(httpContext);
        }
    }

   // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SampleMiddlewareExtensions
    {
        public static IApplicationBuilder UseSampleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SampleMiddleware>();
        }
    }
}
