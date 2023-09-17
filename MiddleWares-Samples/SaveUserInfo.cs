using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MiddleWares_Samples
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SaveUserInfo
    {
        private readonly RequestDelegate _next;

        public SaveUserInfo(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //Here u can write custom MiddleWares

            //Getting user system Info : 
            var userInfo = httpContext.Request.Headers["User-Agent"];

            //Getting user ip Address : 
            string ip = httpContext.Connection.RemoteIpAddress.ToString();

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SaveUserInfoExtensions
    {
        public static IApplicationBuilder UseSaveUserInfo(this IApplicationBuilder builder)
        {
            //This is the Calling MiddleWare that Self is running in a class named UseSaveUserInfo (u can use this in Program.CS)
            return builder.UseMiddleware<SaveUserInfo>();
        }
    }
}
