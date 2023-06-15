namespace Membership.Blazor.WebApiGateway;

public static class DependendencyContainer
{
    public static IServiceCollection AddWebApiGatewayServices(
        this IServiceCollection services, Action<UserEndpointsOptions> userEndpointOptions)
    {

        services.AddHttpClient(nameof(IUserWebApiGateway));

        services.AddScoped<IUserWebApiGateway, UserWebApiGateway>();

        services.Configure<UserEndpointsOptions>(options => userEndpointOptions(options));
        return services;
    }
}