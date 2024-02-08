using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Net;
using System.Text.Json;

namespace WebUI.Middlewares;

public class CustomExceptionHandler(
    ILogger<CustomExceptionHandler> _logger,
    IHostEnvironment _env) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(
        HttpContext context,
        Exception ex,
        CancellationToken cancellationToken)
    {
        _logger.LogError(ex, ex.Message);

        context.Response.ContentType = MediaTypeNames.Application.Json;
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = _env.IsDevelopment()
            ? new { context.Response.StatusCode, ex.Message, Details = ex.StackTrace!.ToString() }
            : new { context.Response.StatusCode, Message = "Internal Server Error", Details = "" };

        var jsonString = JsonSerializer.Serialize(response);
        await context.Response.WriteAsync(jsonString, cancellationToken);

        return true;
    }
}
