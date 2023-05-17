
namespace SpecificationValidation.Abstractions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddValidatorsFromAssembly(this IServiceCollection services
        , Assembly assembly)
    {
        //va a buscar los tipos  que deriven de Specification<T> y de Validator:
        // y que las clases que derivan de  Specification<> sea una implementacion del ISpecification

        // y que las clases que derivan de  Validator<> sea una implementacion del IValidator
        services.RegisterServices(assembly,
                    typeof(Specification<>), typeof(ISpecification<>))
                .RegisterServices(assembly,
                    typeof(Validator<>), typeof(IValidator<>));
        return services;
    }


    //genericInterfaceType: es un tipo de intefaz generica que va a buscar, ej:ISpecification y IValidator
    //genericBaseType: es el tipo base generica que se va a buscar: ej:Specification<> y Validator<>
    private static IServiceCollection RegisterServices(this IServiceCollection services,
        Assembly assembly, Type genericBaseType, Type genericInterfaceType)
    {
        // va a buscar los servicios y las implementaciones en el assembly.
        //filtrando que el tipo tengan herencia (t.BaseType != null),  que sea generico,
        // y que la definicion del generico  sea igual al genericBaseType

        var ServicesAndImplementations = assembly.GetTypes().
            //CONSULTA 1
            Where(t => t.BaseType != null && t.BaseType.IsGenericType &&
                  t.BaseType.GetGenericTypeDefinition() == genericBaseType).
            Select(t => new
            {
                //se realiza otra buscar para  hallar las interfaces de tenga  los tipos
                //que heredan  Specification<>
                Service = t.BaseType.GetInterfaces()
                          //halla que  sea generico y que la definicion del generico sea de tipo
                          //genericInterfaceType (ISpecification)
                          //CONSULTA 2
                          .FirstOrDefault(i => i.IsGenericType &&
                              i.GetGenericTypeDefinition() == genericInterfaceType),

                Implementation = t //t es el tipo cuya clase base no es nula, y que su clase base es generica
                                   // y su clase base es del tipo generico que esta buscando(Specification<> y Validator<>)
            }).ToList();

        //de los elementos encontrados: se realiza el registro del tipo service  y el que implementa
        //ej:  services.AddScoped<ISpecification<Address>, NameSpecification>();
        ServicesAndImplementations.ForEach(s => services.AddScoped(s.Service, s.Implementation));

        return services;
    }
}
