namespace SpecificationValidation.Entities;

public class ValidationException : Exception
{
    public IEnumerable<IValidationError> Errors { get; }
    public ValidationException() : base() { }

    public ValidationException(string message) : base(message) { }

    public ValidationException(string message, Exception innerException) :
        base(message, innerException)
    { }

    public ValidationException(IValidationResult validationResult) :
        base(validationResult.ToString())
    {
        Errors = validationResult.Errors;
    }
}
