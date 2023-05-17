
namespace SpecificationValidation.Abstractions;

public abstract class Validator<T> : IValidator<T>
{
    // vienen las especificaciones
    readonly IEnumerable<ISpecification<T>> Specifications;

    public Validator(IEnumerable<ISpecification<T>> specifications) =>
        Specifications = specifications;



    //valida con la entidad:
    public IValidationResult Validate(T entity) =>
        ValidateEntityOrProperty(entity);

    //valida una propiedad:
    public IValidationResult ValidateProperty(T entity, string propertyName) =>
        ValidateEntityOrProperty(entity, propertyName);


    //es un helper interno:
    ValidationResult ValidateEntityOrProperty(T entity, string properytyName = null)
    {
        ValidationResult ValidationResult = new();
        foreach (var specification in Specifications)
        {
            //por cada especificacion se va evaluando:
            //si properytyName == null  es porque quieren evaluar todo
            bool IsSatisfied = properytyName == null ?

                specification.IsSatisfiedBy(entity) :
                specification.IsSatisfiedBy(entity, properytyName);

            if (!IsSatisfied)
            { //no cumplio la regla
                ValidationResult.AddRange(specification.Errors);
            }

        }
        return ValidationResult;
    }

    public void Guard(T entity)
    {
        var Result = Validate(entity);
        if (!Result.IsValid)
            throw new ValidationException(Result);

    }
}
