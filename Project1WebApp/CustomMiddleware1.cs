using Microsoft.AspNetCore.Http;

namespace Project1WebApp
{
    public class CustomMiddleware1 : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {                      
                await context.Response.WriteAsync("Hello from NewFile 1 \n");

                await next(context);

                await context.Response.WriteAsync("Hello from NewFile 2 \n");
           

        }
    }
}
