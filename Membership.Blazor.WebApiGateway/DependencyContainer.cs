namespace Membership.Blazor.WebApiGateway;

public static class DependendencyContainer
{
    public static IServiceCollection AddWebApiGatewayServices(
        this IServiceCollection services, Action<UserEndpointsOptions> userEndpointOptions)
    {

        services.AddHttpClient();
        services.AddScoped<IUserWebApiGateway, UserWebApiGateway>();
        services.Configure(userEndpointOptions);
        return services;
    }
}