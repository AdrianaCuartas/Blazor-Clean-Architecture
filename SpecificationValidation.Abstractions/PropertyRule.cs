namespace SpecificationValidation.Abstractions;

//va a almacenar las reglas
public class PropertyRule<T>
{
    //nombre de la propiedad al cual se le va aplicar reglas
    internal string PropertyName { get; }

    //la lista de reglas
    internal List<Rule<T>> Rules { get; }

    //para saber que hacer cuando encuentra el primer error
    internal OnFirstErrorAction OnFirstErrorAction { get; private set; }



    //PARA VER TODOS ERRORES, NO SOLO EL ERROR DE UNA PROPRIEDAD
    public PropertyRule<T> ContinueOnError()
    {
        OnFirstErrorAction = OnFirstErrorAction.ContinueValidation;
        return this;
    }
    public PropertyRule(string propertyName)
    {
        PropertyName = propertyName;
        Rules = new();

        OnFirstErrorAction = OnFirstErrorAction.StopValidation;
    }
    public PropertyRule<T> AddRule(Func<T, bool> predicate,
       string errorMessage)
    {
        Rules.Add(new Rule<T>(predicate, errorMessage));
        return this;
    }
}
