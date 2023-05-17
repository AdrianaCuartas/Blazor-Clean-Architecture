
namespace CustomExceptions.HttpHandlers;

internal class RefreshTokenNotFoundExceptionHandler :
    IHttpExceptionHandler<RefreshTokenNotFoundException>
{
    public ProblemDetails Handle(RefreshTokenNotFoundException exception) =>
        new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Invalid Refresh Token"
        };
}



