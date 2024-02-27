public class JwtMiddleware
{
    readonly RequestDelegate next;

    public JwtMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {
        await next(context);
    }

}

public static class JwtMiddlewareExtensions
{
    public static IApplicationBuilder UseJwtMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<JwtMiddleware>();
    }
}