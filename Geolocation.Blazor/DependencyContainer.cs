
using Geolocation.Blazor.Geocoding;
using Geolocation.Blazor.Geocoding.Geoapify;

namespace Geolocation.Blazor;

public static class DependencyContainer
{
    public static IServiceCollection AddGeolocationService(
        this IServiceCollection services) =>
        services.AddScoped<GeolocationService>();

    public static IServiceCollection AddDefaultGeocoderService(
     this IServiceCollection services, string geocoderApiKey)
    {
        services.AddHttpClient<IGeocoder, GeoapifyGeocoder>(httpClient =>
        {
            return new GeoapifyGeocoder(httpClient, geocoderApiKey);
        });
        return services;
    }
}
