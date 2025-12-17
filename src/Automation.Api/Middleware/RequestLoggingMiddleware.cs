
namespace Automation.Api.Middleware;

public class RequestLoggingMiddleware(RequestDelegate next)
{
    
    public async Task InvokeAsync(HttpContext context)
    {
        
        Console.WriteLine($"[{DateTime.UtcNow}] {context.Request.Method} {context.Request.Path}");
        await next(context);

    }

}