namespace Membership.RefreshTokenManager.Memory;

public static class DependendencyContainer
{
    public static IServiceCollection AddRefreshTokenManagerServices(
        this IServiceCollection services)
    {
        services.TryAddSingleton<IRefreshTokenManager, RefreshTokenManager>();

        return services;
    }
}