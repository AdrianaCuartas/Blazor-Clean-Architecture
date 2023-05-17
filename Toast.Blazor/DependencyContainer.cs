using Microsoft.Extensions.DependencyInjection;

namespace Toast.Blazor;

public static class DependencyContainer
{
    public static IServiceCollection AddToastService(this IServiceCollection services)
    {
        services.AddScoped<IToastService, ToastService>();
        return services;
    }
}
