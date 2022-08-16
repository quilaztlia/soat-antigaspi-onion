using Domain.Exceptions;
using LoggerService.Abstractions;
using Newtonsoft.Json;

namespace Antigaspi.Web.Middleware
{
    internal sealed class CustomExceptionHandlerMiddleware : IMiddleware
    {
        //private readonly ILogger<CustomExceptionHandlerMiddleware> _logger;
        private readonly ICustomLoggerManager _logger;

        public CustomExceptionHandlerMiddleware(ICustomLoggerManager logger) =>
            _logger = logger;

        public async Task InvokeAsync(HttpContext httpContext, RequestDelegate next)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                await HandleExceptionAsync(httpContext, exception);
            }
        }

        //CHECK: WHY static ?
        private static async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                _ => StatusCodes.Status500InternalServerError
            };

            var deeperException = exception?.InnerException != null ?
                exception.InnerException.InnerException : exception;

            var httpResponse = new
            {
                error = deeperException?.Message,
                stackTrace = deeperException.StackTrace
            };

            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(httpResponse));
        }
    }
}
