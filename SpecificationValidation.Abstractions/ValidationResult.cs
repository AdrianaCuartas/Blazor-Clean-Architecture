
namespace SpecificationValidation.Abstractions;
//almacenar el resultado de la validacion:
public class ValidationResult : IValidationResult
{
    readonly List<IValidationError> ErrorsField = new();
    public bool IsValid => !ErrorsField.Any(); //para avisale al consumidor
    //si la validacion fue valida

    //para la lista de errores: es un wraper de ErrorsField
    public IEnumerable<IValidationError> Errors => ErrorsField;


    internal void AddRange(IEnumerable<IValidationError> errors) =>
        ErrorsField.AddRange(errors);

    //separa por coma cada uno de los mensajes de errores
    public override string ToString() =>
        string.Join(" ", ErrorsField.Select(e => e.Message));

}
