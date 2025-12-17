
using System.Text.Json;

namespace Automation.Api.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
{
    
    public async Task InvokeAsync(HttpContext context)
    {

        try
        {
            await next(context);
        }catch(Exception ex)
        {
            
            logger.LogError(ex, "Unhandled exception occurred.");

            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";

            var response = new
            {
                error = "An unexpected error occured"
            };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));

        }

    }

}