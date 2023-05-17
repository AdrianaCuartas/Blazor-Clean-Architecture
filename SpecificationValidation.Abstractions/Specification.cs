

namespace SpecificationValidation.Abstractions;

//la clase base para las especificaciones, es abstracta para que no pueda instanciarse
public abstract class Specification<T> : ISpecification<T>
{
    readonly List<ValidationError> ErrorsField = new(); //lista de ValidationError

    readonly List<PropertyRule<T>> PropertyRules = new(); //lista de PropertyRule

    protected PropertyRule<T> Property(Expression<Func<T, object>> property)
    {
        //se va a usar con Property(Address a=> a.Name)
        var PropertyRule = new PropertyRule<T>(ExpressionHelper.
                        GetPropertyName(property));

        PropertyRules.Add(PropertyRule);
        return PropertyRule;
    }

    //metodo para validar reglas:
    bool ValidateRules(T entity, List<PropertyRule<T>> propertyRules)
    {
        ErrorsField.Clear(); //limpia los errores anteriores
        foreach (var Property in propertyRules)
        {
            foreach (var Rule in Property.Rules)
            {
                if (!Rule.Predicate(entity))
                { //no se cumplio el predicado
                    ErrorsField.Add(new ValidationError(Property.PropertyName,
                        Rule.ErrorMessage));
                    if (Property.OnFirstErrorAction == OnFirstErrorAction.StopValidation)
                    {
                        break;
                    }
                }
            }
        }
        return !ErrorsField.Any();
    }

    public IEnumerable<IValidationError> Errors => ErrorsField;


    public bool IsSatisfiedBy(T entity) =>
            ValidateRules(entity, PropertyRules);

    public bool IsSatisfiedBy(T entity, string propertyName) =>
            ValidateRules(entity,
            PropertyRules.Where(pr => pr.PropertyName == propertyName).ToList());


    //se hace un filtro solos de los PropertyRules solo aquellos  que estan pidiendo validar

}
