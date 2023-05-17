namespace CustomExceptions.HttpHandlers;

internal class PersistenceExceptionHanlder : IHttpExceptionHandler<PersistenceException>
{
    public ProblemDetails Handle(PersistenceException exception)
    {
        ProblemDetails ProblemDetails = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = StatusCodes.Status400BadRequestType,
            Title = "Data cannot be saved",
            Details = exception.InnerException == null ? exception.Message :
                        exception.InnerException.Message,

        };

        return ProblemDetails;
    }
}
