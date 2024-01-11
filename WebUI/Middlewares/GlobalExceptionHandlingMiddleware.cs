using Microsoft.AspNetCore.Diagnostics;
using System.Net.Mime;
using System.Net;
using Newtonsoft.Json;
using Core.Exceptions;

namespace WebUI.Middlewares;

public class GlobalExceptionHandlingMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(HttpContext context, ILogger<GlobalExceptionHandlingMiddleware> logger)
    {
        try
        {
            await _next(context);
        }

        catch (Exception ex)
        {
            var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
            if (contextFeature != null)
            {
                logger.LogError(contextFeature.Error.Message);
            }

            var response = new GlobalExceptionResponse((int)HttpStatusCode.InternalServerError, ex.Message, ex.StackTrace);
            context.Response.StatusCode = response.StatusCode;
            context.Response.ContentType = MediaTypeNames.Application.Json;

            var jsonResponse = JsonConvert.SerializeObject(response);
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}
