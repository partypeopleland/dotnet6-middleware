using ClassLibrary1;

namespace WebApplication1.Middleware
{
    public static class Test1MiddlewareExt
    {
        public static void UseTest1(this IApplicationBuilder app)
        {
            app.UseMiddleware<Test1Middleware>();
        }
    }

    public class Test1Middleware
    {
        private readonly RequestDelegate _next;

        // "Scoped" SERVICE SHOULDN'T DO CONSTRUCTOR DI!!
        public Test1Middleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context,MyService myService)
        {
            await context.Response.WriteAsync("Test1Middleware before\r\n");
            await context.Response.WriteAsync($"method inject SCOPE service:{myService.ShowMyMoney()}\r\n");
            await _next(context);
            await context.Response.WriteAsync("Test1Middleware after\r\n");
        }
    }
}
