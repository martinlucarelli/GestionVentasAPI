

using Microsoft.AspNetCore.Http.Extensions;

public class RegisterMethodMiddleware
{
    readonly RequestDelegate next;
    public readonly ILogger<RegisterMethodMiddleware> _logger;


    public RegisterMethodMiddleware(RequestDelegate nextRequest,ILogger<RegisterMethodMiddleware> logger)
    {

        next = nextRequest;
        _logger=logger;
    }

    public async Task Invoke(Microsoft.AspNetCore.Http.HttpContext context)
    {
        var startTime= DateTime.Now;

        await next(context);

        var endTime= DateTime.Now;

        var method = context.Request.Method;
        var url = context.Request.GetDisplayUrl();
        var elapsedTime= endTime-startTime;
        var status = context.Response.StatusCode;

        string statusMessage= "Exitosa";

        if(status > 300)
        {
            statusMessage="Fallida";
        }

        _logger.LogInformation($"Metodo: {method} | URL: {url} | Tiempo: {elapsedTime.TotalSeconds:F3} | Code: {status} | ({statusMessage})");

    }
}


public static class RegisterMethodMiddlewareExtension
{

    public static IApplicationBuilder UseRegisterMethodMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<RegisterMethodMiddleware>();
    }
}