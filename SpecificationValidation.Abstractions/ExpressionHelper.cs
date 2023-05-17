namespace SpecificationValidation.Abstractions;

internal static class ExpressionHelper
{
    //a => a.Name
    //de una expression se obtiene el nombrede la propiedad
    internal static string GetPropertyName<T>(Expression<Func<T, object>>
        propertyExpression)
    {
        //obtiene el cuerpo de la expresion  (es la parte derecha del lambda)
        var MemberExpression = propertyExpression.Body as MemberExpression;

        if (MemberExpression == null)
        {
            throw new ArgumentException("Invalid body expression");
        }
        var Property = MemberExpression.Member as PropertyInfo;
        if (Property == null)
        {
            throw new ArgumentException("The expression must contain the property name");
        }
        return Property.Name;
    }
}
