
namespace BlazingPizza.Desktop.Models;
public static class DependencyContainer
{
    public static IServiceCollection AddDesktopModelsServices(
        this IServiceCollection services)
    {
        services.AddScoped<ISpecialsModel, DesktopSpecialsModel>();
        services.AddScoped<IConfigurePizzaDialogModel,
           DesktopConfigurePizzaDialogModel>();
        services.AddScoped<IOrderStateService, OrderStateService>();

        services.AddScoped<ICheckoutModel, DesktopCheckoutModel>();
        services.AddScoped<IOrdersModel, DesktopOrdersModel>();
        services.AddScoped<IOrderDetailsModel, DesktopOrderDetailsModel>();
        return services;
    }
}


