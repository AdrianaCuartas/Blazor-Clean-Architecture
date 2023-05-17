namespace SpecificationValidation.Entities;

public interface ISpecification<T>
{
    IEnumerable<IValidationError> Errors { get; }
    bool IsSatisfiedBy(T entity);
    bool IsSatisfiedBy(T entity, string propertyName);
}
