namespace WebApplication1.Helpers
{

    public static class RouteHandleMiddlewareExtension
    {
        public static IApplicationBuilder UseRouteHandle(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RouteHandleMiddleware>();
        }
    }
}
