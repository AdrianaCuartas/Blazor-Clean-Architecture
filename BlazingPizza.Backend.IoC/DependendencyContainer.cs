using CustomExceptions.HttpHandlers;
using Membership.IoC;

namespace BlazingPizza.Backend.IoC;
public static class DependendencyContainer
{
    public static IServiceCollection AddBlazingPizzaBackendServices(
        this IServiceCollection services)
    {
        services.AddUseCasesServices()
            .AddRepositoriesServices()
            .AddControllersServices()
            .AddPresentersServices()
            .AddValidatorsServices()
            .AddHttpExceptionHandlersServices()
            .AddMembershipServices();

        return services;
    }
}
