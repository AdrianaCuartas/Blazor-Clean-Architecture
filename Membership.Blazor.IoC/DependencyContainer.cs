using Membership.Blazor.WebApiGateway;
using Microsoft.Extensions.DependencyInjection;

namespace Membership.Blazor.IoC;

public static class DependendencyContainer
{
    public static IServiceCollection AddMembershipBlazorServices(
        this IServiceCollection services, Action<UserEndpointsOptions> userEndpointsSetter)
    {

        services.AddWebApiGatewayServices(userEndpointsSetter);
        return services;
    }
}