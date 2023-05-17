
using Membership.Entities.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Membership.UserService;

public static class DependencyContainer
{
    public static IServiceCollection AddUserServices(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();
        services.TryAddSingleton<IUserService, UserService>();
        return services;
    }

}
