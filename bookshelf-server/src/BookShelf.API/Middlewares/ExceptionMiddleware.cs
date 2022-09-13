using BookShelf.Domain.Constants;
using BookShelf.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BookShelf.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    private readonly IWebHostEnvironment _env;
    
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(
        RequestDelegate next,
        IWebHostEnvironment env,
        ILogger<ExceptionMiddleware> logger
    )
    {
        _next = next;

        _env = env;
        
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleUnhandledExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleUnhandledExceptionAsync(HttpContext context, Exception ex)
    {
        string correlationId = context.Request.Headers[HttpHeaderConstants.CORRELATIONID_HEADER];

        int statusCode = StatusCodes.Status500InternalServerError;

        string exceptionMessage = ex.Message;

        IDictionary<string, string[]> validationErrors = new Dictionary<string, string[]>();

        switch (ex)
        {
            case ItemNotFoundException e:
                statusCode = StatusCodes.Status404NotFound;

                exceptionMessage = e.Message;

                break;

            case InvalidRequestException e:
                statusCode = StatusCodes.Status400BadRequest;
                
                if (e?.Errors is not null)
                {
                    validationErrors = e.Errors;
                }

                exceptionMessage = "Bad request";
                
                break;

            default:
                _logger.LogError("Unhandled exception occured on - {currentDateTime}\r\nTraceId: {correlationId}, {exceptionMessage}", DateTime.UtcNow, correlationId, ex.ToString());
                break;
        }

        ValidationProblemDetails problemDetails = new(validationErrors)
        {
            Status = statusCode,
            Type = $"https://httpstatuses.com/{statusCode}",
            Title = ErrorConstants.GenericErrorMessage,
            Detail = null,
            Instance = context.Request.Path
        };

        if (_env.IsDevelopment())
        {
            problemDetails.Title = exceptionMessage;

            problemDetails.Detail = ex.StackTrace;
        }

        context.Response.ContentType = "application/json";

        context.Response.StatusCode = statusCode;

        await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails, new JsonSerializerOptions
        {
            WriteIndented = true
        }));
    }
}
