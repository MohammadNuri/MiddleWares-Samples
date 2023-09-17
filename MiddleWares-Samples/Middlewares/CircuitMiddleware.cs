using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWares_Samples.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CircuitMiddleware
    {
        private readonly RequestDelegate _next;

        public CircuitMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Checks the browser , if your browser is chrome , it will not load the web page for u (Short Circuit Middleware)

            await _next(httpContext);

            if (httpContext.Request.Headers["UserAgent"].Any(p => p.ToLower().Contains("Chrome")))
            {
                httpContext.Response.StatusCode = 403;
            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CircuitMiddlewareExtensions
    {
        public static IApplicationBuilder UseCircuitMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CircuitMiddleware>();
        }
    }
}
