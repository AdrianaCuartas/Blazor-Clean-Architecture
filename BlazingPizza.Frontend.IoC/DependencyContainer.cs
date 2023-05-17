
using BlazingPizza.OrderTrackerSimulator;
using Geolocation.Blazor;
using Leaflet.Blazor;
using SweetAlert.Blazor;
using Toast.Blazor;

namespace BlazingPizza.Frontend.IoC;
public static class DependencyContainer
{
    public static IServiceCollection AddBlazingPizzaFrontendServices(
        this IServiceCollection services,
       IOptions<EndpointsOptions> endpointsOptions,
       string geocoderapiKey,
        Action<IHttpClientBuilder> httpClientConfigurator = null)
    {
        services.AddModelsServices()
            .AddViewModelsServices()
            .AddBlazingPizzaWebApiGateways(
                endpointsOptions, httpClientConfigurator)
             .AddValidatorsServices()
             .AddToastService()
             .AddSweetAlertService()
             .AddGeolocationService()
             .AddDefaultGeocoderService(geocoderapiKey)
             .AddLeafletServices()
             .AddOrderStatusNotificatorService();

        return services;
    }


}
