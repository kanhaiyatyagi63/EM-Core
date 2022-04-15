using EM.API.Middlewares;

namespace EM.API.Extensions
{
    public static class MiddlewareExtension
    {
        public static void UseGlobalExceptionHandlerMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<GlobalExceptionMiddleware>();
        }
    }
}
