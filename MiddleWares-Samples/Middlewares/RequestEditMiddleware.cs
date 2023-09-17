using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWares_Samples.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RequestEditMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestEditMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            //this one will check the browser if it is chrome , it  will set the http.context.item to chrome true
            httpContext.Items["BrowserIsChrome"] = httpContext.Request.Headers["User-Agent"].Any(p => p.ToLower().Contains("Chrome"));

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RequestEditMiddlewareExtensions
    {
        public static IApplicationBuilder UseRequestEditMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestEditMiddleware>();
        }
    }
}
