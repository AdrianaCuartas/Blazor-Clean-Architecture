using BlazingPizza.Desktop.Models;
using BlazingPizza.ViewModels;
using Microsoft.Extensions.DependencyInjection;
namespace BlazingPizza.Desktop.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaDesktopServices(
         this IServiceCollection services)
    {
        services.AddDesktopModelsServices()
            .AddViewModelsServices();

        return services;
    }
}


