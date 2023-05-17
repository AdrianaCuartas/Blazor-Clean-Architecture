namespace SpecificationValidation.Entities;

public interface IValidationError
{
    string Message { get; }
    string PropertyName { get; }
}
