using System.Net;

namespace Void.Demo
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                // log the error
                _logger.LogError(exception, "error during executing {Context}", httpContext.Request.Path.Value);
               
                var response = httpContext.Response;
                response.ContentType = "application/json";

                //do some fancy error handling
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                var message = System.Text.Json.JsonSerializer.Serialize($"Whoops, something went wrong! -  {exception.Message}");
                await response.WriteAsync(message);
            }
        }
    }
}
