namespace Antigaspi.Web.Middleware
{
    internal sealed class ExceptionHandlingMiddleware : IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            throw new NotImplementedException();
        }
    }
}
