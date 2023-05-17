namespace CustomExceptions;
//la funcion es concentrar  a los mensajes de excepcion
public interface IHttpExceptionHandlerHub
{
    //includeDetails es para ver si incluye el detalle de la excepcion 
    //como en la ejecucion como develpment
    ProblemDetails Handle(Exception ex, bool includeDetails);
}
