namespace CustomExceptions;

public interface IHttpExceptionHandler<ExceptionType>
    where ExceptionType : Exception  //donde exceptiontype debe ser una excepcion
{
    //el manejador debe retorna un ProblemDetails
    ProblemDetails Handle(ExceptionType exception);
}
