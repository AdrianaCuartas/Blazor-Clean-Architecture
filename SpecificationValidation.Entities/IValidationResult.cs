namespace SpecificationValidation.Entities;

public interface IValidationResult
{
    bool IsValid { get; }
    IEnumerable<IValidationError> Errors { get; }

}
