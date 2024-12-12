using System.Net;
using System.Text.Json;
using Dto.Game;

namespace RestApi.Extensions;

public class HttpExceptionMiddleware(RequestDelegate next , ILogger<HttpExceptionMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next(context);
        }
        catch (ExceptionDto ex)
        {
            if (ex.InternalException is not null)
                logger.LogError(ex , "Exception handled by HttpExceptionMiddleware");
            
            await HandleExceptionAsync(context, ex.Message);
        }
        catch (Exception ex)
        {
            logger.LogError(ex , "Generic Exception handled by HttpExceptionMiddleware");
            await HandleExceptionAsync(context, "Error occurred while processing request");
        }
    }

    /// <summary>
    /// convert exception to standard response 
    /// </summary>
    /// <param name="context"></param>
    /// <param name="errorMessage"></param>
    /// <returns></returns>
    private static Task HandleExceptionAsync(HttpContext context, string errorMessage)
    {
        // Set response details
        context.Response.ContentType = "application/json";
        context.Response.StatusCode =  200;

        // Create a standardized error response
        var errorResponse = new ResponseDto()
        {
            Code = 200,
            Errors = [errorMessage]
        };
        var jsonResult = JsonSerializer.Serialize(errorResponse);

        return context.Response.WriteAsync(jsonResult);
    }
    
}