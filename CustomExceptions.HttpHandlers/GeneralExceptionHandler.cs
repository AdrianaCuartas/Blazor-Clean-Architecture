namespace CustomExceptions.HttpHandlers;

internal class GeneralExceptionHandler : IHttpExceptionHandler<GeneralException>
{
    public ProblemDetails Handle(GeneralException exception)
    {
        ProblemDetails ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Type = StatusCodes.Status500InternalServerErrorType,
            Title = exception.Message,
            Details = exception.Detail

        };

        return ProblemDetails;
    }
}
