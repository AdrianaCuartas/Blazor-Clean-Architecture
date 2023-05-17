namespace SpecificationValidation.Entities;

//la funcion es concentrar las validaciones:
public interface IValidator<T>
{
    IValidationResult Validate(T entity);

    IValidationResult ValidateProperty(T entity, string propertyName);

    void Guard(T entity);
}
