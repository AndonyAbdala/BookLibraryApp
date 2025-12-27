using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace BookLibraryApi.Presentation.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
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
                // Si ocurre una excepción, la manejamos aquí
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            // Configuramos la respuesta
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // Objeto de respuesta uniforme
            var response = new
            {
                Success = false,
                Message = ex.Message,
                // En desarrollo puedes incluir detalles
                // StackTrace = ex.StackTrace
            };

            var json = JsonSerializer.Serialize(response);
            return context.Response.WriteAsync(json);
        }
    }
}
