namespace SpecificationValidation.Abstractions;

//para establecer las reglas de validacion: es una regla para una entidad

internal class Rule<T>
{
    public string ErrorMessage { get; } //mensaje de error si no cmple el predicado
    public Func<T, bool> Predicate { get; } //criterio de evaluacion 
    public Rule(Func<T, bool> predicate, string errorMessage)
    {
        Predicate = predicate;
        ErrorMessage = errorMessage;
    }

}
