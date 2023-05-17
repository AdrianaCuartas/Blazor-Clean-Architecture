

namespace BlazingPizza.UseCases;
public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(
        this IServiceCollection services)
    {
        services.AddScoped<IGetSpecialsInputPort, GetSpecialsInteractor>();
        services.AddScoped<IGetToppingsInputPort, GetToppingsInteractor>();
        services.AddScoped<IPlaceOrderInputPort, PlaceOrderInteractor>();
        services.AddScoped<IGetOrdersInputPort, GetOrdersInteractor>();
        services.AddScoped<IGetOrderInputPort, GetOrderInteractor>();

        return services;
    }
}
