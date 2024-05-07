namespace WebApplication1.Helpers
{
    public class RouteHandleMiddleware
    {
        private readonly RequestDelegate _next;

        public RouteHandleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stringQuery = context.Request.Path.Value;

            if (stringQuery == "/sayHello")
            {
                await context.Response.WriteAsync("Hello!");
                return;
            }
            await _next(context);
        }
    }
}
