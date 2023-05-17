using Membership.Entities.Exceptions;

namespace CustomExceptions.HttpHandlers;

//una excepcion pesonalizad cuando un error no se puede registrar un usuario
internal class RegisterUserExceptionHandler : IHttpExceptionHandler<RegisterUserException>
{
    public ProblemDetails Handle(RegisterUserException exception)
    {
        var Errors = new Dictionary<string, List<string>>()
        {
            { "Errors", exception.Errors }
        };

        ProblemDetails problemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = exception.Message,
            Details = "Corrige los siguienes problemas",
            InvalidParams = Errors
        };

        return problemDetails;
    }
}
