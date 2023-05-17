
namespace HttpMessageHandlers
{
    //La funcion de la clase ExceptionDelegatingHandler es interferir las peticiones http y
    //vigilar si hubo algun problema,  si lo hay genera una excepcion 
    //DelegatingHandler: es una clase que intercepta los mensajes HTTP de respuesta
    public class ExceptionDelegatingHandler : DelegatingHandler
    {
        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            //interceptar la repuesta de la llamada 
            HttpResponseMessage Response = await base.SendAsync(request, cancellationToken);


            if (!Response.IsSuccessStatusCode)
            {
                Exception Ex;
                try
                {
                    JsonElement JsonResponse = await Response.Content.ReadFromJsonAsync<JsonElement>();
                    Ex = new ProblemDetailsException(JsonResponse); //si no viene un problemDetails va a generar
                                                                    //una excepcion
                }
                catch
                {
                    string message = Response.StatusCode switch
                    {
                        HttpStatusCode.NotFound => "El recurso solicitado no fue encontrado.",
                        _ => $"{(int)Response.StatusCode} {Response.ReasonPhrase}"
                    };
                    Ex = new Exception(message);
                }
                throw Ex;
            }
            return Response;
        }
    }
}