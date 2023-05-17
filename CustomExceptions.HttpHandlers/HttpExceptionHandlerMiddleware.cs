using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace CustomExceptions.HttpHandlers;

internal class HttpExceptionHandlerMiddleware
{
    //se recibe el contexto http 
    public static async Task WriteResponse(HttpContext context,
        bool includeDetails, IHttpExceptionHandlerHub hub)
    {
        //se recupera la excepcion: se obtiene del contexto 
        IExceptionHandlerFeature ExceptionDetail =
            context.Features.Get<IExceptionHandlerFeature>();
        //la excepcion que nadie atrapó
        Exception Exception = ExceptionDetail.Error;


        if (Exception != null)
        {
            //invoca la metodo handler del HttpExceptionHandlerHub: 
            var ProblemDetails = hub.Handle(Exception, includeDetails);
            //al flujo se le dice que el tipo de contenido
            context.Response.ContentType = "application/problem+json";

            context.Response.StatusCode = ProblemDetails.Status;

            //contenido serializado el Problemdetails
            var Stream = context.Response.Body;
            await JsonSerializer.SerializeAsync(Stream, ProblemDetails);
        }
    }
}
