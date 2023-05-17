using Microsoft.Extensions.DependencyInjection;

namespace Leaflet.Blazor;

public static class DependencyContainer
{
    public static IServiceCollection AddLeafletServices(
        this IServiceCollection services)
    {
        services.AddScoped<LeafletService>();
        return services;
    }
}
