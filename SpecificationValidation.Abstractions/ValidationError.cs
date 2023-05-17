

namespace SpecificationValidation.Abstractions;

// Los mensajes de error
// para saber la causa del fallo durante el proceso de validacion, 
//es un valueobject 
public class ValidationError : IValidationError
{
    public string Message { get; }
    public string PropertyName { get; }

    internal ValidationError(string propertyName, string message) =>
        (PropertyName, Message) = (propertyName, message);

}
