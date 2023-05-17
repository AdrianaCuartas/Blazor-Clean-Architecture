using Membership.Entities.Exceptions;

namespace CustomExceptions.HttpHandlers;

internal class LoginUserExceptionHandler : IHttpExceptionHandler<LoginUserException>
{
    public ProblemDetails Handle(LoginUserException exception) =>
        new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Las credenciales proporcionadas son incorrectas"
        };

}
