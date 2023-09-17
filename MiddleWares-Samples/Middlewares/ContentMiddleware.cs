using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWares_Samples.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ContentMiddleware
    {
        private readonly RequestDelegate _next;

        public ContentMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {

            //if u go to the local/content route u will see the respons as your code

            if (httpContext.Request.Path.ToString().ToLower().Contains("/content"))

              await httpContext.Response.WriteAsync("test for content route response middleware!!");

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ContentMiddlewareExtensions
    {
        public static IApplicationBuilder UseContentMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ContentMiddleware>();
        }
    }
}
