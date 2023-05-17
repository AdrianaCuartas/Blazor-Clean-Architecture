namespace CustomExceptions.HttpHandlers
{
    internal class UnauthorizedAccessExceptionHandler : IHttpExceptionHandler<UnauthorizedAccessException>
    {
        public ProblemDetails Handle(UnauthorizedAccessException exception)
        {
            ProblemDetails ProblemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = StatusCodes.Status401UnauthorizedType,
                Title = "Acceso no autorizado",
                Details = "El recurso solicitado no fue autorizado."
            };

            return ProblemDetails;
        }
    }
}
