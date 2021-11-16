using ClassLibrary1;

namespace WebApplication1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MyMiddleware
    {
        private readonly RequestDelegate _next;

        public MyMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, MyService myService)
        {
            var beforeMoney = myService.SetMyMoney(500);
            await httpContext.Response.WriteAsync($"Before next:{beforeMoney}\r\n");
            await _next(httpContext);
            var afterMoney = myService.SetMyMoney(200);
            await httpContext.Response.WriteAsync($"After next:{afterMoney}\r\n");
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MyMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MyMiddleware>();
        }
    }
}
