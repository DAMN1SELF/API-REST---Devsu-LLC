using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using INCHE.Application.Features;


namespace INCHE.Application.Exceptions
{
    public class ExceptionManager : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            var detalle = !string.IsNullOrWhiteSpace(context.Exception?.InnerException?.Message)
                ? context.Exception.InnerException.Message
                : context.Exception?.Message ?? "Ocurrió un error inesperado.";

            context.Result = new ObjectResult(ResponseApiService.Response(
                StatusCodes.Status500InternalServerError, detalle, context.Exception.Message));

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        }
    }
}
