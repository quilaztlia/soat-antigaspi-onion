using LoggerService;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;

namespace GlobalErrorHandling.Extensions
{
    public static class ExceptionMiddlewareExtensions
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder appBuilder, ILoggerManager logger)
        {
            appBuilder.UseExceptionHandler(errorHandler =>
            {
                errorHandler.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (exceptionHandlerFeature != null)
                    {

                    }
                });
            });
        }
    }
}
