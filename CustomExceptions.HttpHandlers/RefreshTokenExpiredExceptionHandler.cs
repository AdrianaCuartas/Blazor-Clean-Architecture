
namespace CustomExceptions.HttpHandlers;

internal class RefreshTokenExpiredExceptionHandler :
    IHttpExceptionHandler<RefreshTokenExpiredException>
{
    public ProblemDetails Handle(RefreshTokenExpiredException exception) =>
        new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Refresh Token expired"
        };


}
