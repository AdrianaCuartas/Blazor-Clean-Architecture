using System.Reflection;

namespace CustomExceptions.HttpHandlers;

internal class HttpExceptionHandleHub : IHttpExceptionHandlerHub
{
    //Ejemplo de que va  almacenar el diccionario:
    //ValidationException, ValidationExceptionHandler
    //PersistenceException, PersistenceExceptionHandler
    readonly Dictionary<Type, Type> ExceptionHandlers = new();

    public HttpExceptionHandleHub(Assembly assembly)
    {
        //se necesita encontrar la excepcion y quien lo maneja.
        //se quiere los tipos, no las instancias
        Type[] Types = assembly.GetTypes(); //todos los tipos del ensamblado
        foreach (Type T in Types)
        {
            //va a obtener las clases que implemente IHttpExceptionHandler:
            var Handlers = T.GetInterfaces() // T.GetInterfaces():obtiene las interfaces genericas
                .Where(i => i.IsGenericType &&
                i.GetGenericTypeDefinition() == typeof(IHttpExceptionHandler<>)); //busca que implemente IHttpExceptionHandler
            foreach (Type Handler in Handlers)
            {
                //obtener la excepcion:
                //Se obtuvo el IHttpExceptionHandler<ValidException>
                //se debe obtener el ValidException
                var ExceptionType = Handler.GetGenericArguments()[0];

                ExceptionHandlers.TryAdd(ExceptionType, T);
            }

        }
    }

    public ProblemDetails Handle(Exception ex, bool includeDetails)
    {
        ProblemDetails Problem;

        //buscar en el diccionario la excepcion el tipo de la excepcion y si lo
        //encuentra lo deja en HandlerType
        if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type HandlerType))
        {
            //se crea una instancia del tipo
            var HandlerInstance = Activator.CreateInstance(HandlerType);

            Problem = (ProblemDetails)
               HandlerType
               .GetMethod(nameof(IHttpExceptionHandler<Exception>.Handle))
               .Invoke(HandlerInstance, new object[] { ex }); //invoca al correspondiente handler

        }
        else
        {
            string Title = "Ha ocurrido un error al procesar la respuesta.";
            string Details;
            if (includeDetails)
            {
                //Title = ex.Message;
                Details = ex.Message + " " + ex.ToString();
            }
            else
            {

                Details = "Consulte al administrador.";
            }
            Problem = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = StatusCodes.Status500InternalServerErrorType,
                Details = Details,
                Title = Title
            };

            //aqui podria ir el registro al log
        }
        return Problem;
    }
}
