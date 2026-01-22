using BookLibraryApi.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace BookLibraryApi.Presentation.Middlewares
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

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Intentamos ejecutar el siguiente middleware / controlador
                await _next(context);
            }
            catch (Exception ex)
            {
                LogException(context, ex);
                // Si ocurre una excepción, la manejamos aquí
                await HandleExceptionAsync(context, ex);
            }
        }

        private void LogException(HttpContext context, Exception ex)
        {
            _logger.LogError(
                ex,
                "Unhandled exception. Method: {Method}, Path: {Path}",
                context.Request.Method,
                context.Request.Path
            );
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Configuramos la respuesta
            context.Response.ContentType = "application/json";
            var statusCode = ex switch
            {
                NotFoundException => HttpStatusCode.NotFound,
                ValidationException => HttpStatusCode.BadRequest,
                _ => HttpStatusCode.InternalServerError
            };

            context.Response.StatusCode = (int)statusCode;

            // Objeto de respuesta uniforme
            var response = new
            {
                Success = false,
                Message = statusCode == HttpStatusCode.InternalServerError
                    ? "An unexpected error occurred."
                    : ex.Message
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
