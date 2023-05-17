using Membership.Presenters;
using Membership.RefreshTokenManager.Memory;

namespace Membership.IoC;
public static class DependendencyContainer
{
    public static IServiceCollection AddCoreMembershipServices(
        this IServiceCollection services)
    {
        services.AddMembershipControllers();
        services.AddUserManagerCoreServices(); //interactor
        services.AddUserServices(); //si el usuario esta autenticado
        services.AddMembershipPresenters();
        return services;
    }

    public static IServiceCollection AddMembershipServices(
        this IServiceCollection services)
    {
        services.AddCoreMembershipServices();
        services.AddAspNetIdentityServices();//persistencia para agregar un nuevo usuario
        services.AddRefreshTokenManagerServices();
        return services;
    }
}