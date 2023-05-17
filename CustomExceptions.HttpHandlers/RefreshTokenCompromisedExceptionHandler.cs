namespace CustomExceptions.HttpHandlers;

internal class RefreshTokenCompromisedExceptionHandler :
    IHttpExceptionHandler<RefreshTokenNotFoundException>
{
    public ProblemDetails Handle(RefreshTokenNotFoundException exception) =>
        new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Revoked Refresh Token"
        };
}
