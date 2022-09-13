using BookShelf.Domain.Constants;

namespace BookShelf.API.Middlewares;

public class CorrelationIdMiddleware
{
    private readonly RequestDelegate _next;
    
    public CorrelationIdMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        string correlationId = Guid.NewGuid().ToString();

        if (!context.Request.Headers.ContainsKey(HttpHeaderConstants.CORRELATIONID_HEADER))
        {
            context.Request.Headers.Add(HttpHeaderConstants.CORRELATIONID_HEADER, correlationId);
        }

        context.Response.OnStarting(() =>
        {
            context.Response.Headers.Add(HttpHeaderConstants.CORRELATIONID_HEADER, correlationId);

            return Task.CompletedTask;
        });

        await _next(context);
    }
}